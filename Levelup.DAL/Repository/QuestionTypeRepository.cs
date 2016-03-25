using Levelup.Data.Core;
using Levelup.DAL.Abstract;
using Levelup.DAL.Context;

namespace Levelup.DAL.Repository
{
    public class QuestionTypeRepository : GenericRepository<QuestionType>,IQuestionTypeRepository
    {
        public QuestionTypeRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}