using Levelup.Data.Core;
using Levelup.DAL.Abstract;
using Levelup.DAL.Context;

namespace Levelup.DAL.Repository
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}