using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Levelup.Data.Core
{
    public class Department : BaseEntity
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }

        //[JsonIgnore]
        public List<Test> Tests { get; set; }
        //[JsonIgnore]
        public List<UserHistory> UserHistories { get; set; }
    }
}
