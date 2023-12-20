using System;
using BaseProject.Application.Repositories.TestRepository;
using BaseProject.Domain.Entities;
using BaseProject.Persistence.Contexts;

namespace BaseProject.Persistence.Repositories.TestRepository
{
    public class TestReadRepository : ReadRepository<Test>, ITestReadRepository
    {
        public TestReadRepository(BaseProjectDbContext dbContext) : base(dbContext)
        {
        }
    }
}

