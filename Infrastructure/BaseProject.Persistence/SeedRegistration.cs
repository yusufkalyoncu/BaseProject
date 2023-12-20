using System;
using BaseProject.Persistence.Seeds;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProject.Persistence
{
    public static class SeedRegistration
    {
        public static void AddSeeds(this IServiceProvider services)
        {
            try
            {
                UserRoleSeed.Seed(services).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}

