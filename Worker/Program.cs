HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "CheetahToolbox";
});

builder.Services.AddHostedService<Toolbox.Service.WindowsService>();

IHost host = builder.Build();
host.Run();