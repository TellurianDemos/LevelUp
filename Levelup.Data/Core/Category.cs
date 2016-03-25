using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levelup.Data.Core
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }

        //[JsonIgnore]
        public List<CategoriesInTest> CategoriesInTest { get; set; }
        //[JsonIgnore]
        public List<Question> Questions { get; set; }

        //public Category()
        //{
        //    CategoriesInTest = new List<CategoriesInTest>();
        //    Questions = new List<Question>();
        //}
    }
}
