using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levelup.Data.Core
{
    public class Question : BaseEntity
    {
        public int CategoryId { get; set; }
        public int ComplexityLevelId { get; set; }
        public int QuestionTypeId { get; set; }
        public string Title { get; set; }
        public int Time { get; set; }
        public int Score { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }
        [JsonIgnore]
        public QuestionType QuestionType { get; set; }
        [JsonIgnore]
        public ComplexityLevel ComplexityLevel { get; set; }
        //[JsonIgnore]
        public List<Answer> Answers { get; set; }
        //[JsonIgnore]
        public List<PassedTest> PassedTests { get; set; }

        //public Question()
        //{
        //    Answers = new List<Answer>();
        //    PassedTests = new List<PassedTest>();
        //}
    }
}
