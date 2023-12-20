using BaseProject.Application.Abstractions.TokenAbstractions;
using BaseProject.Infrastructure.Services.TokenServices;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            //example: Services.AddTransient<IBaseService, BaseService>();
            services.AddTransient<ITokenHandler, TokenHandler>();
        }
    }
}

