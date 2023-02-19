using ARQ.RabbitMQ.Consumer.Worker.Domain.Model.Configs;
using ARQ.RabbitMQ.Consumer.Worker.Domain.Model.Http;
using ARQ.RabbitMQ.Consumer.Worker.Domain.Service;
using ARQ.RabbitMQ.Consumer.Worker.Domain.Service.Interface;
using ARQ.RabbitMQ.Consumer.Worker.Infrastructure.Data.Repository;
using ARQ.RabbitMQ.Consumer.Worker.Infrastructure.Data.Repository.Interface;
using StackExchange.Redis;

namespace ARQ.RabbitMQ.Consumer.Worker.Infrastructure.CrossCutting.Configurations
{
    public static class Injector
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IResponse, Response>();
            services.AddScoped<IExemploService, ExemploService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IExemploRepository, ExemploRepository>();
            return services;
        }

        public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqConfig = new RabbitMqConfig();
            ConfigurationBinder.Bind(configuration, nameof(RabbitMqConfig), rabbitMqConfig);
            services.AddSingleton(rabbitMqConfig);
            services.AddSingleton<IMessageBus, RabbitMqBus>();
            return services;
        }

        public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(c => ConnectionMultiplexer.Connect(configuration.GetValue<string>("RedisConfig:Server")));
            services.AddTransient<IRedisService, RedisService>();
            return services;
        }

        public static IServiceCollection AddLog(this IServiceCollection services, IConfiguration configuration)
        {


            return services;
        }

        public static IServiceCollection AddAppSettingsFileConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionSettings>(opt => configuration.GetSection("ConnectionStrings").Bind(opt));
            services.Configure<RedisConfig>(opt => configuration.GetSection("RedisConfig").Bind(opt));
            return services;
        }
    }
}
