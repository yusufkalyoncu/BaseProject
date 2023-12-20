using System;
using BaseProject.Application.Repositories.TestRepository;
using BaseProject.Domain.Entities;
using BaseProject.Persistence.Contexts;

namespace BaseProject.Persistence.Repositories.TestRepository
{
    public class TestWriteRepository : WriteRepository<Test>, ITestWriteRepository
    {
        public TestWriteRepository(BaseProjectDbContext dbContext) : base(dbContext)
        {
        }
    }
}

