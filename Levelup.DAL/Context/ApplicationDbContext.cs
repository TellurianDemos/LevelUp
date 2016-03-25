using Levelup.Data.Core;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levelup.DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<CategoriesInTest> CategoriesInTests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<ComplexityLevel> ComplexityLevels { get; set; }
        public DbSet<PassedTest> PassedTests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<UserHistory> UserHistories { get; set; }

        public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = false;
        }
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
