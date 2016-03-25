using Levelup.DAL.Abstract;
using Levelup.DAL.Context;
using Levelup.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levelup.DAL.Repository
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext dataContext) : base(dataContext)
        {

        }
    }
}
