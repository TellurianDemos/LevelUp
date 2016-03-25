using Levelup.Data.Core;
using Levelup.DAL.Abstract;
using Levelup.DAL.Context;

namespace Levelup.DAL.Repository
{
    public class PassedTestRepository : GenericRepository<PassedTest>, IPassedTestRepository
    {
        public PassedTestRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}