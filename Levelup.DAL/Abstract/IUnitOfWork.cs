using System;
using System.Threading.Tasks;

namespace Levelup.DAL.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IAnswerRepository Answers { get;}
        ICategoriesInTestRepository CategoriesInTest { get; }
        ICategoryRepository Categories { get; }
        IComplexityLevelRepository ComplexityLevels { get; }
        IDepartmentRepository Departments{ get; }
        IPassedTestRepository PassedTests { get; }
        IQuestionRepository Questions { get; }
        IQuestionTypeRepository QuestionTypes { get; }
        ISkillLevelRepository SkillLevels { get; }
        ITestRepository Tests { get; }
        IUserHistoryRepository UserHistories { get; }
        Task<bool> SaveAsync();
    }
}