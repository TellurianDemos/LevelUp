using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levelup.Data.Core
{
    public class SkillLevel:BaseEntity
    {
        public string Title { get; set; }

        //[JsonIgnore]
        public List<UserHistory> UserHistories { get; set; }
        //[JsonIgnore]
        public List<Test> Tests { get; set; }

        //public SkillLevel()
        //{
        //    UserHistories= new List<UserHistory>();
        //    Tests = new List<Test>();
        //}
    }
}
