using System;
using BaseProject.Domain.Entities.Common;

namespace BaseProject.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> models);

        bool HardDelete(T model);
        Task<bool> HardDeleteAsync(string id);
        bool HardDeleteRange(List<T> models);

        bool SoftDelete(T model);
        Task<bool> SoftDeleteAsync(string id);
        bool SoftDeleteRange(List<T> models);

        bool Update(T model);

        Task<int> SaveAsync();
    }
}

