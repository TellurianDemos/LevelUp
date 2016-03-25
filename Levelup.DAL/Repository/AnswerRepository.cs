using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Levelup.Data.Core;
using Levelup.DAL.Abstract;
using Levelup.DAL.Context;

namespace Levelup.DAL.Repository
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}
