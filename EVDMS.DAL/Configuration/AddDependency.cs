using System;
using EVDMS.DAL.Database;
using EVDMS.DAL.Repositories.Abstractions;
using EVDMS.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EVDMS.DAL.Configuration;

public static class AddDependency
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
    }

    // Add repo DI here
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IDealerRepository, DealerRepository>();
        services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ITestDriveRepository, TestDriveRepository>();
        services.AddScoped<IInventoryRepository, InventoryRepository>();
        services.AddScoped<IPromotionRepository, PromotionRepository>();
        services.AddScoped<IRawSQL, RawSQL>();
    }
}
