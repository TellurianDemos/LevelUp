using Levelup.Data.Core;
using Levelup.DAL.Abstract;
using Levelup.DAL.Context;

namespace Levelup.DAL.Repository
{
    public class SkillLevelRepository : GenericRepository<SkillLevel>, ISkillLevelRepository
    {
        public SkillLevelRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}