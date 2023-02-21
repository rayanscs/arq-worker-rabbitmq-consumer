using ARQ.RabbitMQ.Consumer.Worker.Domain.Interface.RabbitMq;
using ARQ.RabbitMQ.Consumer.Worker.Domain.Interface.Repository;
using ARQ.RabbitMQ.Consumer.Worker.Domain.Interface.Service;
using ARQ.RabbitMQ.Consumer.Worker.Domain.Model.Configs;
using ARQ.RabbitMQ.Consumer.Worker.Domain.Model.Http;
using ARQ.RabbitMQ.Consumer.Worker.Domain.Service;
using ARQ.RabbitMQ.Consumer.Worker.Infrastructure.Data.Repository;
using StackExchange.Redis;

namespace ARQ.RabbitMQ.Consumer.Worker.Infrastructure.CrossCutting.IoC
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
            configuration.Bind(nameof(RabbitMqConfig), rabbitMqConfig);
            services.AddSingleton(rabbitMqConfig);
            services.AddSingleton<IRabbitMqBusService, RabbitMqBusService>();
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
