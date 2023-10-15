using System;
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

            DbContextOptionsBuilder<BaseProjectDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.GetConnectionString);
            return new(dbContextOptionsBuilder.Options);

        }
    }
}

