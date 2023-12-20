using BaseProject.Application.Abstractions.AuthAbstractions;
using BaseProject.Application.Abstractions.UserAbstractions;
using BaseProject.Application.Repositories.TestRepository;
using BaseProject.Common.Configurations;
using BaseProject.Domain.Entities.Identity;
using BaseProject.Persistence.Contexts;
using BaseProject.Persistence.Repositories.TestRepository;
using BaseProject.Persistence.Services.AuthServices;
using BaseProject.Persistence.Services.UserServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {
            //$env:ConnectionStrings:DefaultConnection = "Connection String"
            var configuration = ConfigurationHelper.GetConfiguration();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            Console.WriteLine($"Add Service : {configuration.GetConnectionString("DefaultConnection")}");

            services.AddDbContext<BaseProjectDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<UserEntity, RoleEntity>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<BaseProjectDbContext>()
              .AddDefaultTokenProviders();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();

            services.AddScoped<ITestReadRepository, TestReadRepository>();
            services.AddScoped<ITestWriteRepository, TestWriteRepository>();

        }
    }
}

