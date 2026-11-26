using Microsoft.Extensions.Options;
using System.IO;

namespace CsvFolderProcessor;

public class Worker(ILogger<Worker> logger, IOptions<WatchOptions> options) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
       Console.WriteLine($"Watching folder: {options.Value.FolderWatched}");
       FileSystemWatcher watcher = new FileSystemWatcher(options.Value.FolderWatched);
       
       watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite 
          | NotifyFilters.FileName;

       watcher.Created += OnCreated;
       watcher.Filter = "*.txt";
       watcher.EnableRaisingEvents = true;


    }

    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        FileInfo file = new FileInfo(e.FullPath);
        Console.WriteLine($"- {file.Name} criado em {options.Value.FolderWatched}");
    }
}
