using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Levelup.Data.Core
{
    public class ApplicationUser : IdentityUser
    //    <string, ApplicationUserLogin,
    //ApplicationUserRole, ApplicationUserClaim>, IUser<string>
    {
        public string FullName { get; set; }
        public DateTime RegisterDate { get; set; }

        //[JsonIgnore]
        public virtual List<UserHistory> UserHistories { get; set; }
        //[JsonIgnore]
        public virtual List<PassedTest> PassedTests { get; set; }

        //public ApplicationUser()
        //{
        //    UserHistories = new List<UserHistory>();
        //    PassedTests = new List<PassedTest>();
        //}


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
