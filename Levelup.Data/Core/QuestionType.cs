using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levelup.Data.Core
{
    public class QuestionType : BaseEntity
    {
        public string Title { get; set; }

        //[JsonIgnore]
        public List<Question> Questions { get; set; }

        //public QuestionType()
        //{
        //    Questions = new List<Question>();
        //}
    }
}
