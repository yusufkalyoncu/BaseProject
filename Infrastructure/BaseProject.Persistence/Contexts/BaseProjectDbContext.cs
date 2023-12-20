using BaseProject.Domain.Entities;
using BaseProject.Domain.Entities.Common;
using BaseProject.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace BaseProject.Persistence.Contexts
{
    public class BaseProjectDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
    {

        public BaseProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        // for change environment on cli : $env:ASPNETCORE_ENVIRONMENT='Production'

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<BaseEntity>();

            foreach (var entity in entities)
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.CreatedAt = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        if (entity.Entity.IsDeleted)
                        {
                            entity.Entity.DeletedAt = DateTime.UtcNow;
                        }
                        else
                        {
                            entity.Entity.UpdatedAt = DateTime.UtcNow;
                        }
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
