using Levelup.Data.Core;
using Levelup.DAL.Abstract;
using Levelup.DAL.Context;

namespace Levelup.DAL.Repository
{
    public class TestRepository : GenericRepository<Test>, ITestRepository
    {
        public TestRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}