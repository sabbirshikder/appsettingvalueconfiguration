using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WorkerService1;

//IHost host = Host.CreateDefaultBuilder(args)
//    .ConfigureServices((hostContext, services) =>
//    {
//        IConfiguration configuration = hostContext.Configuration;
//        services.Configure<SMSServiceConfiguration>(configuration.GetSection("SMSServiceConfiguration"));
//        services.AddSingleton(provider => provider.GetRequiredService<IOptions<SMSServiceConfiguration>>().Value);
//        services.AddHostedService<Worker>();
//    })
//    .Build();

//host.Run();

IHostBuilder builder = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
        options.ServiceName = ".NET Joke Service";
    })
    .ConfigureServices((context, services) =>
    {
        services.AddHostedService<Worker>();
        IConfiguration configuration = context.Configuration;
        services.Configure<SMSServiceConfiguration>(configuration.GetSection("SMSServiceConfiguration"));
        services.AddSingleton(provider => provider.GetRequiredService<IOptions<SMSServiceConfiguration>>().Value);

        // See: https://github.com/dotnet/runtime/issues/47303
        services.AddLogging(builder =>
        {
            builder.AddConfiguration(
                context.Configuration.GetSection("Logging"));
        });
    });
IHost host = builder.Build();
host.Run();