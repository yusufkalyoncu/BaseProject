using Microsoft.EntityFrameworkCore;
using BaseProject.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;

namespace BaseProject.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //example: Services.AddTransient<IBaseService, BaseService>();

            services.AddDbContext<BaseProjectDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}

