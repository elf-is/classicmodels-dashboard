using Dashboard.Common.Helpers;
using Dashboard.Data;
using Dashboard.Data.DTO;
using Dashboard.Data.Models;
using Dashboard.Interfaces;
using Dashboard.Services;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static void RegisterDataServices(this IServiceCollection services)
    {
        var host = Environment.GetEnvironmentVariable("MYSQL_HOST");
        var user = Environment.GetEnvironmentVariable("MYSQL_USER");
        var password = Environment.GetEnvironmentVariable("MYSQL_ROOT_PASSWORD");
        var database = Environment.GetEnvironmentVariable("MYSQL_DATABASE");
        var connectionString = $"server={host};user={user};password={password};database={database}";
        services.AddDbContext<ClassicModelsContext>
        (options => options
            .UseMySql(
                connectionString,
                ServerVersion.Parse("10.4.24-mariadb"),
                option => option.EnableRetryOnFailure())
        );
    }

    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IDataTableService<Customer>, DataTableService<Customer>>();
        services.AddScoped<IDataTableService<CustomerDTO>, DataTableService<CustomerDTO>>();
    }
}