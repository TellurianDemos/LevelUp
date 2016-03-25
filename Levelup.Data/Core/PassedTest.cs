using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Levelup.Data.Core
{
    public class PassedTest : BaseEntity
    {
        public int TestId { get; set; }
        public string ApplicationUserId { get; set; }
        public int QuestionId { get; set; }
        public DateTime DateTime { get; set; }
        public bool Result { get; set; }

        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }
        [JsonIgnore]
        public Question Question { get; set; }
        [JsonIgnore]
        public Test Test { get; set; }
    }
}
