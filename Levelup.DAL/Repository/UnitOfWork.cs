using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Levelup.DAL.Abstract;
using Levelup.DAL.Context;

namespace Levelup.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dataContext;
        private IAnswerRepository _answer;
        private ICategoriesInTestRepository _categoriesInTest;
        private ICategoryRepository _category;
        private IComplexityLevelRepository _complexityLevel;
        private IDepartmentRepository _department;
        private IPassedTestRepository _passedTest;
        private IQuestionRepository _question;
        private IQuestionTypeRepository _questionType;
        private ISkillLevelRepository _skillLevel;
        private ITestRepository _test;
        private IUserHistoryRepository _userHistory;

        public UnitOfWork()
        {
            _dataContext = new ApplicationDbContext();
        }

        public IAnswerRepository Answers
        {
            get { return _answer ?? (_answer = new AnswerRepository(_dataContext)); }
        }

        public ICategoriesInTestRepository CategoriesInTest
        {
            get { return _categoriesInTest ?? (_categoriesInTest = new CategoriesInTestRepository(_dataContext)); }
        }

        public ICategoryRepository Categories
        {
            get { return _category ?? (_category = new CategoryRepository(_dataContext)); }
        }

        public IComplexityLevelRepository ComplexityLevels
        {
            get { return _complexityLevel ?? (_complexityLevel = new ComplexityLevelRepository(_dataContext)); }
        }

        public IDepartmentRepository Departments
        {
            get { return _department ?? (_department = new DepartmentRepository(_dataContext)); }
        }

        public IPassedTestRepository PassedTests
        {
            get { return _passedTest ?? (_passedTest = new PassedTestRepository(_dataContext)); }
        }

        public IQuestionRepository Questions
        {
            get { return _question ?? (_question = new QuestionRepository(_dataContext)); }
        }

        public IQuestionTypeRepository QuestionTypes
        {
            get { return _questionType ?? (_questionType = new QuestionTypeRepository(_dataContext)); }
        }

        public ISkillLevelRepository SkillLevels
        {
            get { return _skillLevel ?? (_skillLevel = new SkillLevelRepository(_dataContext)); }
        }

        public ITestRepository Tests
        {
            get { return _test ?? (_test = new TestRepository(_dataContext)); }
        }

        public IUserHistoryRepository UserHistories
        {
            get { return _userHistory ?? (_userHistory = new UserHistoryRepository(_dataContext)); }
        }

        public async Task<bool> SaveAsync()
        {
            try
            {
                await _dataContext.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }

        #region IDisposable

        public virtual void Dispose()
        {
            _dataContext.Dispose();
        }

        #endregion
    }
}
