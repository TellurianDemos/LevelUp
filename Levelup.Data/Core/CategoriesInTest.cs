using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levelup.Data.Core
{
    public class CategoriesInTest : BaseEntity
    {
        public int TestId { get; set; }

        public int CategoryId { get; set; }
        public int ComplexityLevelId { get; set; }
        public int PassingScore { get; set; }
        public int Persentage { get; set; }

        [JsonIgnore]
        public Test Test { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        [JsonIgnore]
        public ComplexityLevel ComplexityLevel { get; set; }
    }
}
