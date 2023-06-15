using Dashboard.Data;

namespace Dashboard.Common.Extensions;

public static class HostExtensions
{
    public static void AddLoggingConfiguration(this IHostBuilder hostBuilder)
    {
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Development")
            hostBuilder.ConfigureLogging((_, logging) =>
            {
                logging.ClearProviders();
                logging.AddSystemdConsole(options => options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ");
                logging.AddFilter("Microsoft", LogLevel.Warning);
                logging.AddFilter("Microsoft.Hosting.Lifetime", LogLevel.Information);
            });
    }

    public static void CreateDbIfNotExists(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ClassicModelsContext>();
        context.Database.EnsureCreated();
    }
}