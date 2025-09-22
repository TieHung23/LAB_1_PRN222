using System;
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
}
