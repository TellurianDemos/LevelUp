using Levelup.Data.Core;
using Levelup.DAL.Abstract;
using Levelup.DAL.Context;

namespace Levelup.DAL.Repository
{
    public class UserHistoryRepository : GenericRepository<UserHistory>,IUserHistoryRepository
    {
        public UserHistoryRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}