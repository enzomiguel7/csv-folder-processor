using Microsoft.Extensions.Options;

namespace CsvFolderProcessor;

public class Worker(ILogger<Worker> logger, IOptions<WatchOptions> options) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                logger.LogInformation($"Folder being watched: {options.Value.FolderWatched}, Time interval: {options.Value.TimeInterval}");
            }
            await Task.Delay(1000, stoppingToken);
        }
    }
}
