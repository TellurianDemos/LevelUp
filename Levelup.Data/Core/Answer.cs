using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levelup.Data.Core
{
    public class Answer : BaseEntity
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public bool IsTrue { get; set; }

        [JsonIgnore]
        public Question Question { get; set; }
    }
}
