using ARQ.RabbitMQ.Consumer.Worker;
using ARQ.RabbitMQ.Consumer.Worker.Infrastructure.CrossCutting.IoC;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = AppSettingsFileConfigurations.GetConfiguration();
        services.AddSingleton<IConfiguration>(c => configuration);
        services.AddRabbitMq(configuration);
        services.AddRedis(configuration);
        services.AddRepositories(configuration);
        services.AddLog(configuration);
        services.AddServices(configuration);
        services.AddHostedService<Worker>();
    })
    .Build();

host.RunAsync();
