using System.Data.Entity;
using Levelup.Data.Core;

namespace Levelup.DAL.Context
{
    //custom
    public interface IApplicationDbContext
    {
        DbSet<Answer> Answers { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<CategoriesInTest> CategoriesInTests { get; set; }
        DbSet<ComplexityLevel> ComplexityLevels { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<PassedTest> PassedTests { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<QuestionType> QuestionTypes { get; set; }
        DbSet<SkillLevel> SkillLevels { get; set; }
        DbSet<Test> Tests { get; set; }
        DbSet<UserHistory> UserHistories { get; set; }
    }
}