using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using derpibooruCSharpDownloader.Database;
using derpibooruCSharpDownloader.Database.Entity;
using derpibooruCSharpDownloader.ThreadedDownloader;
using FunctionQueues;
using MoreLinq;
using NDepend.Path;
using Newtonsoft.Json;
using Nito.AsyncEx;

namespace derpibooruCSharpDownloader
{

    public class Downloader
    {
        public List<Search> SearchList { get; set; } = new List<Search>();
        public List<Search> ToDownloadSearchList { get; set; } = new List<Search>();

        public List<long> AlreadyContainsHash = new List<long>(); 

        public BlockingCollection<WebClient> ClientQueue = new BlockingCollection<WebClient>();
        public List<Uri> Pages = new List<Uri>();


        public void BuildDownloadedFiles()
        {
            AlreadyContainsHash.Clear();
            Directory.CreateDirectory(Configuration.Instance.SaveLocation);
            string[] filePaths = Directory.GetFiles(Configuration.Instance.SaveLocation, "*",
                                         SearchOption.AllDirectories);

            foreach (var filePath in filePaths)
            {
                int id;
                if(int.TryParse(Path.GetFileNameWithoutExtension(filePath), out id))
                    AlreadyContainsHash.Add(id);
            }

            AlreadyContainsHash = AlreadyContainsHash.OrderBy(c => c).ToList();
        }

        public bool CheckForCache(string searchTerms)
        {
            var deserialized = GetCache(searchTerms);
            if (deserialized == null)
                return false;
            SearchList = deserialized;

            return true;
        }

        private static List<Search> GetCache(string searchTerms)
        {
            var cachedString = GetCachedString(searchTerms);
            if (cachedString == null)
                return null;
            var deserialized = JsonConvert.DeserializeObject<List<Search>>(cachedString);
            return deserialized;
        }

        private static string GetCachedString(string searchTerms)
        {
            var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\derpibooruDL\\";

            if (!Directory.Exists(documentsFolder))
                Directory.CreateDirectory(documentsFolder);


            var fileName = searchTerms;

            var invalidFileChars = Path.GetInvalidFileNameChars().ToList();
            invalidFileChars.ForEach(c => fileName = fileName.Replace(c.ToString(), String.Empty));

            fileName = fileName + ".cache";

            documentsFolder += fileName;

            if (!File.Exists(documentsFolder))
                return null;

            var cachedString = File.ReadAllText(documentsFolder);
            return cachedString;
        }

        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();  //or use SHA1.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        FunctionQueueService _fqs = new FunctionQueueService();

        public async Task Search(string searchTerms)
        {
            BuildDownloadedFiles();

            if (CheckForCache(searchTerms))
            {
                Debug.WriteLine("Loaded from Cache");
                await FinishedDownloading(true, searchTerms);
                return;
            }

            var client = new WebClient();

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            var terms = searchTerms.Split(',');

            for (int i = 0; i < terms.Length; i++)
            {
                terms[i] = terms[i].Replace(' ', '+');
            }


            int currentPage = 1;

            var joinedString = string.Join("%2C", terms);
            var url =
                new Uri("https://derpiboo.ru/search.json?q=" + joinedString + "&page=" + 1 + "&key=" +
                        Configuration.Instance.APIKey);

            var jsonString = client.DownloadString(url);


            var converted = JsonConvert.DeserializeObject<SearchContainer>(jsonString);

            float totalLinks = converted.total;
            float numberOfPicsPerPage = converted.search.Count;
            Debug.WriteLine("Total Links Found on Search : " + totalLinks);
            int numberOfPages = (int) Math.Ceiling(totalLinks/(float)numberOfPicsPerPage) + 2;
            
            if(Configuration.Instance.NumOfPages != 0)
                numberOfPages =  Math.Min(numberOfPages, Configuration.Instance.NumOfPages);
            
            var iSkip = 0;
            var iSkipTo = 0;

            for (int i = 1; i <= numberOfPages; i++)
            {
                if (iSkip < iSkipTo)
                {
                    iSkip++;
                    continue;
                }
                var uri =
                    new Uri("https://derpiboo.ru/search.json?q=" + joinedString + "&page=" + i + "&key=" +
                            Configuration.Instance.APIKey);
                Pages.Add(uri);
            }

            Program.Form.progressLabel.Text = "Searching";
            Program.Form.TotalProgressLabel.Text = numberOfPages.ToString("N0");
            Program.Form.currentProgressLabel.Text = "0";
            Program.Form.progressBar.Maximum = numberOfPages;
            
            var cQueue = new ConcurrentQueue<Search>();
            var i2 = 0;
            var i3 = 0;
            await _fqs.ProcessWorkAsync<FQueues.FQueueSearch, Uri>(Pages, async (page) =>
            {
                SearchContainer container = null;
                int tries = 0;
                while (tries <= 10)
                {
                    container = await GetSearchContainer(page);
                    if (container != null)
                        break;
                    //await Task.Delay(100);
                    tries++;
                }
                if (container == null)
                {
                    Debugger.Break();
                }
                else
                {
                    i3 = i3 + container.search.Count;
                    Console.WriteLine(i3 + " " + container.search.Count);
                    container.search.ForEach(x =>
                    {
                        i2++;
                        cQueue.Enqueue(x);
                    });
                }
            }, i =>
            {
                UpdateProgress(numberOfPages, i.CurrentCount);
                var list = new List<Search>();
                int iQueue = 0;
                //if(cQueue.Count != 0)
                    //Console.WriteLine("Database Items left to process: {0}", cQueue.Count);
                while (!cQueue.IsEmpty && iQueue < 100)
                {
                    Search res = null;
                    cQueue.TryDequeue(out res);
                    list.Add(res);
                    iQueue++;
                }
                return BatchProcessDb(list);
            });
            
            while (!cQueue.IsEmpty)
            {
                var list2 = new List<Search>();
                int iQueue = 0;
                if (cQueue.Count != 0)
                    Console.WriteLine("Database Items left to process: {0}", cQueue.Count);
                while (!cQueue.IsEmpty && iQueue < 100)
                {
                    Search res = null;
                    cQueue.TryDequeue(out res);
                    list2.Add(res);
                    iQueue++;
                }
                await BatchProcessDb(list2);
            }
            //SearchList.AddRange(cQueue);

            //await FinishedDownloading(false, searchTerms);

            int bob = 1;
        }

        private static async Task<SearchContainer> GetSearchContainer(Uri page)
        {
            try
            {
                var uriHash = GetHashString(page.ToString());
                var cached = GetCachedString(uriHash);
                if (cached != null)
                {
                    return JsonConvert.DeserializeObject<SearchContainer>(cached);
                }
                using (var hClient = new HttpClient())
                {
                    var value = await hClient.GetStringAsync(page).ConfigureAwait(false);
                    //SaveCache(uriHash, value);
                    return JsonConvert.DeserializeObject<SearchContainer>(value);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task FinishedDownloading(bool fromCache = false, string searchTerms = null)
        {
            //cache search by termsString
            //if(!fromCache)
            //    SaveCache(searchTerms, JsonConvert.SerializeObject(SearchList));

            await SaveSearchResultsToDb(SearchList.DistinctBy(x => x.id_number).ToList()).ConfigureAwait(false);
            

            }

        private static void SaveCache(string fileName, string text)
        {
            var documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                  "\\derpibooruDL\\";

            if (!Directory.Exists(documentsFolder))
                Directory.CreateDirectory(documentsFolder);


            var invalidFileChars = Path.GetInvalidFileNameChars().ToList();
            invalidFileChars.ForEach(c => fileName = fileName.Replace(c.ToString(), String.Empty));


            documentsFolder += fileName + ".cache";
            
            File.WriteAllText(documentsFolder, text);
        }

        private static async Task SaveSearchResultsToDb(List<Search> searchList)
        {
            var total = searchList.Count;
            
            Program.Form.progressLabel.Text = "Updating Database";
            Program.Form.TotalProgressLabel.Text = total.ToString("N0");
            Program.Form.currentProgressLabel.Text = "0";
            Program.Form.progressBar.Maximum = total;

            Dictionary<long, DerpyImage> derpyImages;

            using (var db = new DerpyDbContext())
            {
                derpyImages =
                    await db.DerpyImages.ToDictionaryAsync(x => x.DerpyImageId);
            }

            var failedItems = new List<Search>();
            
                await searchList.ProcessBatchWorkAsync(async (search, latch) => {
                        //await BatchProcessDb(search.ToList(), failedItems, latch);
                    }, i =>
                    {
                        UpdateProgress(total, i.CurrentCount);
                        return Task.FromResult<object>(null);
                    }, 100);
            
        }

        private static void UpdateProgress(int total, int i)
        {
            try
            {
                var currentCount = total - i;
                Program.Form.Invoke(new Action(() =>
                {
                    Program.Form.progressBar.Value = currentCount;
                    Program.Form.currentProgressLabel.Text = currentCount.ToString("N0");
                    Program.Form.progressPerctLabel.Text = ((currentCount/total)*100).ToString("N0");
                }));
            }
            catch (Exception)
            {
                Program.Form.progressBar.Value = Program.Form.progressBar.Maximum;
            }
        }

        private static async Task BatchProcessDb(List<Search> search)
        {
            var processed = new CountdownEvent(0);
            using (var db = new DerpyDbContext())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;

                foreach (var item in search)
                {
                    try
                    {
                        var tries = 0;
                        while (tries <= 10)
                        {
                            if (await CreateImageIfNeeded(item, db, processed))
                                break;
                            tries++;
                            await Task.Delay(10);
                        }
                        if (tries >= 10)
                            throw new Exception();
                    }
                    catch (Exception ex)
                    {
                        //failedItems.Add(item);
                    }
                    //latch.Signal();
                }
                await db.SaveChangesAsync().ConfigureAwait(false);
            }
            if(processed.CurrentCount != 0)
                Console.WriteLine("Processed New Database Images: {0}", processed.CurrentCount);
        }

        private static async Task<bool> CreateImageIfNeeded(Search search, DerpyDbContext db, CountdownEvent processed)
        {
            if (await db.DerpyImages.AnyAsync(x => x.DerpyImageId == search.id_number))
            {
                //Debugger.Break();
            }
            else
            {
                processed.Reset(processed.CurrentCount + 1);
                var dImage = Mapper.Map<DerpyImage>(search);
                dImage.DerpyImageId = search.id_number;
                dImage.Representations.Id = dImage.Id;
                dImage.Representations.DerpyRepresentationId = dImage.Id;

                try
                {
                    db.DerpyImages.Add(dImage);
                }
                catch (InvalidOperationException)
                {
                    return false;
                }

            }
            return true;
        }


        TDownloader downloader = new TDownloader();

        object _lock = new object();
        public async Task DownloadPictures()
        {
            BuildDownloadedFiles();

            var derpyImages = GetDerpyImages();

            if (derpyImages.Count == 0)
            {
                FinishedDownloadingPics();
                return;
            }

            
            var toDownload = derpyImages.Count;
            var downloaded = 0;

            var latch = new CountdownEvent(toDownload);

            Program.Form.Invoke(new Action(() =>
            {
                Program.Form.progressBar.Maximum = toDownload;
                Program.Form.progressLabel.Text = "Downloading";

                Program.Form.TotalProgressLabel.Text = toDownload.ToString("N0");
                Program.Form.currentProgressLabel.Text = "0";
            }));
            
            foreach (var search in derpyImages)
            {
                downloader.QueueItem(new WorkItem(search.GetImageUri().ToString(), search.DerpyImageId, GetFilePathForSearch(search).ToAbsoluteFilePath(),
                    async item =>
                    {
                        lock (_lock)
                        {
                            downloaded++;
                        }
                    }));
            }
            
            while (downloaded < toDownload)
            {
                try
                {
                    var downloaded2 = 0;
                    lock (_lock)
                    {
                        downloaded2 = downloaded;
                    }
                    UpdateProgress(toDownload, downloaded2);
                }
                catch (Exception)
                {
                    Program.Form.Invoke(new Action(() =>
                    {
                        Program.Form.progressBar.Value = Program.Form.progressBar.Maximum;
                    }));
                    
                }
                await Task.Delay(100).ConfigureAwait(false);
            }
            

            FinishedDownloadingPics();
        }

        public async void FinishedDownloadingPics()
        {
            Debug.WriteLine("Finished Downloading all pics");

            Program.Form.EnableSearchButton();
        }

        public List<DerpyImage> GetDerpyImages()
        {
            var derpyImages = new List<DerpyImage>();

            var searchTags = Configuration.Instance.LastSearchTerm.ToLowerInvariant().Replace(" ", "").Split(',').ToList();
            

            using (var db = new DerpyDbContext())
            {
                derpyImages = db.DerpyImages.Include(x => x.Representations).Where(c => !AlreadyContainsHash.Contains(c.DerpyImageId) && searchTags.All(tag => c.Tags.Contains(tag))).ToList();
            }

            
           // derpyImages = derpyImages.Where(search => !AlreadyContainsHash.Contains(search.DerpyImageId)).ToList();


            if (derpyImages.Count == 0)
            {
                FinishedDownloadingPics();
                return new List<DerpyImage>();
            }


            if (Configuration.Instance.ImageWidth > 0)
                derpyImages = derpyImages.Where(search => search.Width >= Configuration.Instance.ImageWidth).ToList();

            if (Configuration.Instance.ImageHeight > 0)
                derpyImages = derpyImages.Where(search => search.Height >= Configuration.Instance.ImageHeight).ToList();


            if (Configuration.Instance.MinRating > 0)
                derpyImages = derpyImages.Where(search => search.Score >= Configuration.Instance.MinRating).ToList();


            switch (Configuration.Instance.OrderingSelectedIndex)
            {
                case 0: // ratings
                    derpyImages = derpyImages.OrderByDescending(search => search.Score).ToList();
                    break;
                case 1: // newest
                    derpyImages = derpyImages.OrderByDescending(search => search.DerpyImageId).ToList();
                    break;
                case 2: // oldest
                    derpyImages = derpyImages.OrderBy(search => search.DerpyImageId).ToList();
                    break;
                case 3: // Favorites
                    derpyImages = derpyImages.OrderByDescending(search => search.Favourites).ToList();
                    break;
                case 4: // Random
                    derpyImages.Shuffle();
                    break;

            }

            //restrict the images last
            if (Configuration.Instance.NumOfPicsTotal != 0)
            {
                while (derpyImages.Count > Configuration.Instance.NumOfPicsTotal)
                {
                    derpyImages.RemoveAt(derpyImages.Count-1);
                }
            }

            return derpyImages;
        }

        public void SortList()
        {
            switch (Configuration.Instance.OrderingSelectedIndex)
            {
                case 0: // ratings
                    SearchList = SearchList.OrderByDescending(search => search.score).ToList();
                    break;
                case 1: // newest
                    SearchList = SearchList.OrderByDescending(search => search.id_number).ToList();
                    break;
                case 2: // oldest
                    SearchList = SearchList.OrderBy(search => search.id_number).ToList();
                    break;
                case 3: // Favorites
                    SearchList = SearchList.OrderByDescending(search => search.faves).ToList();
                    break;
                case 4: // Random
                    SearchList.Shuffle();
                    break;

            }
        }


        public string GetFilePathForSearch(DerpyImage search)
        {
            var extension = Path.GetExtension(search.GetImageUri().ToString());

            var additionalFolder = "\\";
            if (!search.Tags.Contains("safe"))
                additionalFolder = "\\NSFW\\";

            if (!Directory.Exists(Configuration.Instance.SaveLocation + additionalFolder))
                Directory.CreateDirectory(Configuration.Instance.SaveLocation + additionalFolder);

            var savePath = Configuration.Instance.SaveLocation + additionalFolder + search.DerpyImageId.ToString();
            

            

            savePath = savePath + extension;

            return savePath;
        }



        




        /// <summary>
        ///     Downloads a file from a specified Internet address.
        /// </summary>
        /// <param name="remotePath">Internet address of the file to download.</param>
        /// <param name="localPath">
        ///     Local file name where to store the content of the download, if null a temporary file name will
        ///     be generated.
        /// </param>
        /// <param name="timeOut">Duration in miliseconds before cancelling the  operation.</param>
        /// <returns>A tuple containing the remote path, the local path and an exception if one occurred.</returns>
        private static async Task<Tuple<string, string, Exception>> DownloadFileTaskAsync(string remotePath,
            string localPath = null, int timeOut = 3000000)
        {
            try
            {
                if (remotePath == null)
                {
                    Debug.WriteLine("DownloadFileTaskAsync (null remote path): skipping");
                    throw new ArgumentNullException("remotePath");
                }

                if (localPath == null)
                {
                    Debug.WriteLine(
                        string.Format(
                            "DownloadFileTaskAsync (null local path): generating a temporary file name for {0}",
                            remotePath));
                    localPath = Path.GetTempFileName();
                }

                using (var client = new WebClient())
                {
                    TimerCallback timerCallback = c =>
                    {
                        var webClient = (WebClient)c;
                        if (!webClient.IsBusy) return;
                        webClient.CancelAsync();
                        Debug.WriteLine(string.Format("DownloadFileTaskAsync (time out due): {0}", remotePath));
                    };
                    using (var timer = new Timer(timerCallback, client, timeOut, Timeout.Infinite))
                    {
                        await client.DownloadFileTaskAsync(remotePath, localPath);
                    }
                    Debug.WriteLine(string.Format("DownloadFileTaskAsync (downloaded): {0}", remotePath));
                    return new Tuple<string, string, Exception>(remotePath, localPath, null);
                }
            }
            catch (Exception ex)
            {
                return new Tuple<string, string, Exception>(remotePath, null, ex);
            }
        }

    }

    

   


}
