using System.Globalization;

namespace ARQ.RabbitMQ.Consumer.Worker.Infrastructure.CrossCutting.IoC
{
    public static class AppSettingsFileConfigurations
    {
        public static IConfigurationRoot GetConfiguration()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");
            var ambiente = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")?.Trim();

            if (string.IsNullOrWhiteSpace(ambiente))
            {
                Console.WriteLine("A variável de ambiente DOTNET_ENVIRONMENT não foi definida. Aplicação será finalizada.");
                Environment.Exit(1);
            }

            return new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"), false)
                    .AddJsonFile(Path.Combine(AppContext.BaseDirectory, $"appsettings.{ambiente}.json"), false, true)
                    .AddInMemoryCollection(new Dictionary<string, string?>
                    {
                        ["Environment"] = ambiente
                    }).Build();

        }
    }
}
