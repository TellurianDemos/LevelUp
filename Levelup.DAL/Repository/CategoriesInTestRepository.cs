using Levelup.Data.Core;
using Levelup.DAL.Abstract;
using Levelup.DAL.Context;

namespace Levelup.DAL.Repository
{
    public class CategoriesInTestRepository : GenericRepository<CategoriesInTest>, ICategoriesInTestRepository
    {
        public CategoriesInTestRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}