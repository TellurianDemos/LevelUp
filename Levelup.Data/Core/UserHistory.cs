using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levelup.Data.Core
{
    public class UserHistory : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public int DepartmentId { get; set; }
        public int SkillLevelId { get; set; }
        public DateTime PromoteDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }
        [JsonIgnore]
        public Department Department { get; set; }
        [JsonIgnore]
        public SkillLevel SkillLevel { get; set; }

    }
}
