using CsvFolderProcessor;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddOptions<WatchOptions>()
    .BindConfiguration("MonitoringSettings");

var host = builder.Build();
host.Run();
