using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NDepend.Path;
using Nito.AsyncEx;

namespace derpibooruCSharpDownloader.ThreadedDownloader
{
    public static class FQueues
    {
        //Order bottom to top in order of prefered connection.
        internal readonly static ConcurrentBag<DownloadPoint> DownloadPoints = new ConcurrentBag<DownloadPoint>(new[]
        {
            new DownloadPoint((uri) => new Uri("http://web.archive.org/" + uri), 10), //Wayback Machine
            new DownloadPoint((uri) => new Uri(uri), 10), //Default Direct
            //new DownloadPoint((uri) => new Uri("https://proxy-nl.hide.me/go.php?u=" + Uri.EscapeUriString(uri) + "&b=5&f=norefer"), 3), //NL Proxy
            //new DownloadPoint((uri) => new Uri("https://proxy-us.hide.me/go.php?u=" + Uri.EscapeUriString(uri) + "&b=5&f=norefer"), 3), //US Proxy
            //new DownloadPoint((uri) => new Uri("https://proxy-de.hide.me/go.php?u=" + Uri.EscapeUriString(uri) + "&b=5&f=norefer"), 3), //Germany Proxy
        });

        public sealed class FQueueGeneric : IFQueue
        {
            public int MaxWorkers
            {
                get { return DownloadPoints.Sum(x => x.MaxOperations); }
            }
        }
        public sealed class FQueueSearch : IFQueue
        {
            public int MaxWorkers
            {
                get { return 1; }
            }
        }
        public sealed class FQueueDatabase : IFQueue
        {
            public int MaxWorkers
            {
                get { return 1; }
            }
        }
    }

    class TDownloader
    {
        private readonly IAbsoluteDirectoryPath _downloadDirectory;

        FQueueCollection _fQueue;

        ConcurrentQueue<WorkItem> _workItems = new ConcurrentQueue<WorkItem>();
        private CancellationTokenSource _cts;

        public TDownloader()
        {
            _cts = new CancellationTokenSource();
            _fQueue = FQueueCollection.Create<FQueues.FQueueGeneric>(_cts.Token);
        }

        public void QueueItem(WorkItem item)
        {
            _fQueue.AddWork(new FQueueObject((token) => RunQueue(item), _cts.Token));
        }

        private static readonly int MaxTries = 50;

        private async Task RunQueue(WorkItem item)
        {
            var finished = false;
            var tries = 0;
            while (!finished && tries < MaxTries)
            {
                tries++;
                foreach (var downloadPoint in FQueues.DownloadPoints)
                {
                    if (await
                            downloadPoint.TryStartOperation(item).ConfigureAwait(false))
                    {
                        finished = true;
                        break;
                    }
                }
                if (!finished)
                    Console.WriteLine("Item: {0} - Tries: {1}", item.Id, tries);
            }

            item.Finished = finished;
            await item.Callback(item).ConfigureAwait(false);
        }

        
    }

    class WorkItem
    {
        public string Uri { get; private set; }
        public long Id { get; private set; }
        public Func<WorkItem, Task> Callback { get; private set; }
        public IAbsoluteFilePath SaveLocation { get; set; }
        public Search Search { get; set; }
        public bool Finished { get; set; }

        public WorkItem(string uri, long id, IAbsoluteFilePath saveLocaton, Func<WorkItem, Task> callback)
        {
            Uri = uri;
            Id = id;
            SaveLocation = saveLocaton;
            Callback = callback;
        }
    }

    public sealed class FQueueObject
    {
        readonly CancellationToken? _token;
        public Func<CancellationToken, Task> Act { get; private set; }
        public Task CompletionTask { get; private set; }
        public FQueueState State { get; set; }
        public Exception ThrowEx { get; set; }

        public FQueueObject(Func<CancellationToken, Task> act, CancellationToken? token)
        {
            _token = token;
            Act = act;
            State = FQueueState.Waiting;
            if (_token != null)
                CompletionTask = WaitForCompletion();
        }

        async Task WaitForCompletion()
        {
            while (State != FQueueState.Finished)
            {
                if (State == FQueueState.Waiting && _token.Value.IsCancellationRequested)
                    throw new TaskCanceledException();
                if (ThrowEx != null)
                    throw ThrowEx;
                await Task.Delay(100, _token.Value).ConfigureAwait(false);
            }
        }
    }

    public enum FQueueState
    {
        Waiting,
        Processing,
        Finished
    }
    public sealed class FQueueCollection
    {
        object _lock = new object();
        int _activeWorkers;

        private FQueueCollection()
        {
            Queue = new ConcurrentQueue<FQueueObject>();
        }

        private FQueueCollection(ConcurrentQueue<FQueueObject> queue)
        {
            Queue = queue;
        }

        public ConcurrentQueue<FQueueObject> Queue { get; private set; }
        public int ActiveWorkers
        {
            get { return _activeWorkers; }
            private set
            {
                if (QueueType != null)
                    Console.WriteLine("Queue Changed: " + QueueType.GetType().Name + " - " + ActiveWorkers + " -> " + value);
                _activeWorkers = value;
            }
        }
        public int MaxWorkers { get; private set; }
        IFQueue QueueType { get; set; }
        CancellationToken Token { get; set; }

        public static FQueueCollection Create<TQueue>(CancellationToken token)
            where TQueue : class, IFQueue, new()
        {
            var q = new TQueue();
            return new FQueueCollection() { MaxWorkers = q.MaxWorkers, ActiveWorkers = 0, Token = token, QueueType = q };
        }
        public static FQueueCollection Create<TQueue>(ConcurrentQueue<FQueueObject> queue, CancellationToken token)
            where TQueue : class, IFQueue, new()
        {
            var q = new TQueue();
            return new FQueueCollection(queue) { MaxWorkers = q.MaxWorkers, ActiveWorkers = 0, Token = token, QueueType = q };
        }


        public void AddWork(FQueueObject qObject, bool startWorking = true)
        {
            Queue.Enqueue(qObject);
            if(startWorking)
                TryStartNewWorker();
        }

        public void StartWorking()
        {
            var toStart = MaxWorkers;
            if (Queue.Count >= MaxWorkers)
            {
                for (int i = 0; i < MaxWorkers - ActiveWorkers; i++)
                {
                    TryStartNewWorker();
                }
            }
            else
            {
                for (int i = 0; i < Queue.Count - ActiveWorkers; i++)
                {
                    TryStartNewWorker();
                }
            }
        }

        void TryStartNewWorker()
        {
            lock (_lock)
            {
                if (ActiveWorkers >= MaxWorkers)
                    return;
                ActiveWorkers++;
                Task.Factory.StartNew(() => RunQueue(Token), TaskCreationOptions.LongRunning);
            }
        }

        async Task<FQueueObject> GetItem(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                FQueueObject request = null;
                var tryDequeue = Queue.TryDequeue(out request);
                if (tryDequeue)
                {
                    return request;
                }
            }
            return null;
        }

        async Task RunQueue(CancellationToken token)
        {
            FQueueObject request = null;
            try
            {
                while (!token.IsCancellationRequested)
                {
                    request = await GetItem(new CancellationTokenSource(100).Token);
                    lock (_lock)
                    {
                        if (request == null)
                        {
                            ActiveWorkers -= 1;
                            break;
                        }
                    }
                    request.State = FQueueState.Processing;
                    try
                    {
                        await request.Act(token).ConfigureAwait(false);
                    }
                    finally
                    {
                        request.State = FQueueState.Finished;
                    }
                }
            }
            catch (Exception ex)
            {
                Debugger.Break();
            }

        }
    }


    public interface IFQueue
    {
        int MaxWorkers { get; }

    }

    class DownloadPoint
    {
        protected readonly Func<string, Uri> _createUrl;
        protected readonly int _maxOperations;
        protected int _operations = 0;
        protected object _lock = new object();

        public DownloadPoint(Func<string, Uri> createUrl, int maxOperations = 3)
        {
            _createUrl = createUrl;
            _maxOperations = maxOperations;
        }

        public int Operations
        {
            get { return _operations; }
        }

        public int MaxOperations
        {
            get { return _maxOperations; }
        }

        public async Task<bool> TryStartOperation(WorkItem item)
        {
            lock (_lock)
            {
                if (Operations == _maxOperations)
                    return false;
                _operations++;
            }
            try
            {
                await
                    StartOperation(_createUrl(item.Uri), item.SaveLocation)
                        .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                lock (_lock)
                {
                    _operations--;
                }
            }

            return true;
        }

        protected virtual async Task StartOperation(Uri uri, IAbsoluteFilePath filePath)
        {
            using (var client = new HttpClient())
            {
                using (var request = await client.GetAsync(uri).ConfigureAwait(false))
                {
                    request.EnsureSuccessStatusCode();
                    await SaveFileStream(filePath, request.Content).ConfigureAwait(false);
                }
            }
        }

        private async Task SaveFileStream(IAbsoluteFilePath path, HttpContent stream)
        {
            using (var fileStream = new FileStream(path.ToString(), FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream).ConfigureAwait(false);
            }
        }
    }
}
