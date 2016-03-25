using Levelup.Data.Core;
using Levelup.DAL.Abstract;
using Levelup.DAL.Context;

namespace Levelup.DAL.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}