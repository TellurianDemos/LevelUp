using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levelup.Data.Core
{
    public class ComplexityLevel : BaseEntity
    {
        public string Title { get; set; }

        //[JsonIgnore]
        public virtual List<CategoriesInTest> CategoriesInTests { get; set; }
        //[JsonIgnore]
        public virtual List<Question> Questions { get; set; }

        //public ComplexityLevel()
        //{
        //    CategoriesInTests = new List<CategoriesInTest>();
        //    Questions = new List<Question>();
        //}
    }
}
