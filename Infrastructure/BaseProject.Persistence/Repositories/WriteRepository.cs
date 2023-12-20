using System;
using BaseProject.Application.Repositories;
using BaseProject.Domain.Entities.Common;
using BaseProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BaseProject.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly BaseProjectDbContext _dbContext;

        public WriteRepository(BaseProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<T> Table => _dbContext.Set<T>();



        //METHODS

        public async Task<bool> AddAsync(T model)
        {
            if (model == null) return false;

            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> models)
        {
            if (models == null || !models.Any()) return false;

            await Table.AddRangeAsync(models);
            return true;
        }

        public bool HardDelete(T model)
        {
            if (model == null) return false;

            EntityEntry<T> entityEntry = Table.Remove(model);

            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> HardDeleteAsync(string id)
        {
            T? model = await Table.FindAsync(Guid.Parse(id));
            if (model == null) return false;

            return HardDelete(model);
        }

        public bool HardDeleteRange(List<T> models)
        {
            if (models == null || !models.Any()) return false;

            Table.RemoveRange(models);
            return true;
        }

        public bool SoftDelete(T model)
        {
            if (model == null) return false;

            model.IsDeleted = true;
            model.DeletedAt = DateTime.UtcNow;

            return true;
        }

        public async Task<bool> SoftDeleteAsync(string id)
        {
            T? model = await Table.FindAsync(Guid.Parse(id));
            if (model == null) return false;

            model.IsDeleted = true;
            model.DeletedAt = DateTime.UtcNow;

            return true;

        }

        public bool SoftDeleteRange(List<T> models)
        {
            if (models == null || !models.Any()) return false;

            foreach (var model in models)
            {
                model.IsDeleted = true;
                model.DeletedAt = DateTime.UtcNow;
            }

            return true;
        }

        public bool Update(T model)
        {
            if (model == null) return false;

            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}

