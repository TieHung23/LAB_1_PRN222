using System;
using EVDMS.BLL.Services.Abstractions;
using EVDMS.BLL.Services.Implementations;
using EVDMS.DAL.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EVDMS.BLL.WrapConfiguration;

public static class AddDependencyDAL
{
    public static void AddDatabaseDAL(this IServiceCollection services, IConfiguration config)
    {
        services.AddDatabase(config);
    }

    // Add repo in DAL
    public static void AddRepositoryDAL(this IServiceCollection services)
    {
        services.AddRepositories();
    }

    // Add services
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IDealerService, DealerService>();
        services.AddScoped<IAccountService, AccountService>();
    }
}
