using System;
using BaseProject.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}

