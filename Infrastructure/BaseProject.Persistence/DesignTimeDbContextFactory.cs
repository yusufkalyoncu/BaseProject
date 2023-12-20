using BaseProject.Common.Configurations;
using BaseProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BaseProject.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BaseProjectDbContext>
    {
        public BaseProjectDbContext CreateDbContext(string[] args)
        {
            var configuration = ConfigurationHelper.GetConfiguration();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            Console.WriteLine($"Design Time : {connectionString}");

            DbContextOptionsBuilder<BaseProjectDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(connectionString);

            return new BaseProjectDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
