using BaseProject.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace BaseProject.Persistence.Contexts
{
    public class BaseProjectDbContext : DbContext
    {

        public BaseProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        // for change environment : $env:ASPNETCORE_ENVIRONMENT='Production'
        // example dbset 
        // public DbSet<Product> Products { get; set; }
        //  public DbSet<BaseEntity> BaseEntities { get; set; }
    }
}
