using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace derpibooruCSharpDownloader
{
    public class OfflineBrowser
    {
        public List<string> FilePaths { get; set; } = new List<string>(); 
        public int CurrentPicIndex = 0;

        public void TabLoaded()
        {
            if (FilePaths.Count != 0)
                return;

            var filePaths = Directory.GetFiles(Configuration.Instance.SaveLocation, "*",
                SearchOption.TopDirectoryOnly).ToList();

          //  var nsfwFilePaths = Directory.GetFiles(Configuration.Instance.SaveLocation + "\\NSFW", "*",
           //     SearchOption.TopDirectoryOnly).ToList();


           // filePaths.AddRange(nsfwFilePaths);

            FilePaths.AddRange(filePaths);

            FilePaths = FilePaths.Where(path => !path.Contains("Thumb")).OrderBy(path => Int32.Parse(Path.GetFileNameWithoutExtension(path))).ToList();
            if(FilePaths.Any())
                Program.Form.offlinePicBox.Load(FilePaths[CurrentPicIndex]);
        }

        public void NextPicture()
        {
            ++CurrentPicIndex;

            CurrentPicIndex = Math.Max(CurrentPicIndex, 0);
            CurrentPicIndex = Math.Min(CurrentPicIndex, FilePaths.Count);

            Program.Form.offlinePicBox.Image.Dispose();
            Program.Form.offlinePicBox.Load(FilePaths[CurrentPicIndex]);
        }

        public void PreviousPicture()
        {
            --CurrentPicIndex;

            CurrentPicIndex = Math.Max(CurrentPicIndex, 0);
            CurrentPicIndex = Math.Min(CurrentPicIndex, FilePaths.Count);

            Program.Form.offlinePicBox.Image.Dispose();
            Program.Form.offlinePicBox.Load(FilePaths[CurrentPicIndex]);
        }

        public void RateImage(int rating)
        {
            var ratingFolder = Configuration.Instance.SaveLocation + string.Format("\\{0} Star", rating);

            if(!Directory.Exists(ratingFolder))
                Directory.CreateDirectory(ratingFolder);

            var fileToMove = FilePaths[CurrentPicIndex];
            var fileName = Path.GetFileName(fileToMove);

            var destFile = ratingFolder + "\\" + fileName;

            Program.Form.offlinePicBox.Image.Dispose();
            FilePaths.RemoveAt(CurrentPicIndex);
            Program.Form.offlinePicBox.Load(FilePaths[CurrentPicIndex]);

            File.Move(fileToMove, destFile);



        }

        public void DeletePicture()
        {
            var fileToRemove = FilePaths[CurrentPicIndex];

            Program.Form.offlinePicBox.Image.Dispose();
            FilePaths.RemoveAt(CurrentPicIndex);
            Program.Form.offlinePicBox.Load(FilePaths[CurrentPicIndex]);

            try
            {
                File.Delete(fileToRemove);
            }
            catch (Exception e)
            {
                
                Debug.WriteLine("Failed to delete File : " + fileToRemove);
            }
        }

    }
}
