using Levelup.Data.Core;
using Levelup.DAL.Abstract;
using Levelup.DAL.Context;

namespace Levelup.DAL.Repository
{
    public class ComplexityLevelRepository : GenericRepository<ComplexityLevel>, IComplexityLevelRepository
    {
        public ComplexityLevelRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}