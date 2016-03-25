using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levelup.Data.Core
{
    public class Test : BaseEntity
    {
        public int DepartmentId { get; set; }
        public int SkillLevelId { get; set; }
        public int AmountQuestions { get; set; }
        public string ImagePath { get; set; }

        [JsonIgnore]
        public Department Department { get; set; }
        [JsonIgnore]
        public SkillLevel SkillLevel { get; set; }
        //[JsonIgnore]
        public List<PassedTest> PassedTests { get; set; }
        //[JsonIgnore]
        public List<CategoriesInTest> CategoriesInTest { get; set; }

        //public Test()
        //{
        //    PassedTests = new List<PassedTest>();
        //    CategoriesInTest = new List<CategoriesInTest>();
        //}
    }
}
