using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Levelup.Data.Core;
using Levelup.DAL.Context;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using Levelup.DAL.Abstract;
using Levelup.WebService.Services;
using System.Linq;

namespace Levelup.WebService
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.


    public class ApplicationUserManager : UserManager<ApplicationUser>, IUserRepository
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
        
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = false,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            manager.EmailService = new EmailService();
            return manager;
        }

        public async Task<bool> UsersInRoleExistAsync(string rolename)
        {
            using (ApplicationRoleStore store = new ApplicationRoleStore())
            {
                using (ApplicationRoleManager rolemanager = new ApplicationRoleManager(store))
                {
                    IdentityRole role = (IdentityRole)(await rolemanager.FindByNameAsync(rolename));
                    var result = role.Users.Count > 0 ? true : false;
                    return await Task<bool>.FromResult<bool>(result);
                }

            }
        }
    }


    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole> store)
            : base(store)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var manager = new ApplicationRoleManager(new ApplicationRoleStore());
            return manager;
        }
    }

    public class ApplicationRoleStore : IRoleStore<ApplicationRole>
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public Task CreateAsync(ApplicationRole role)
        {
            db.Roles.Add(role);
            return db.SaveChangesAsync();

        }

        public Task DeleteAsync(ApplicationRole role)
        {
            db.Roles.Remove(role);
            return db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public Task<ApplicationRole> FindByIdAsync(string roleId)
        {
            return Task.FromResult<ApplicationRole>((ApplicationRole)db.Roles.Find(roleId));
        }

        public Task<ApplicationRole> FindByNameAsync(string roleName)
        {
            Task<IdentityRole> findrole = db.Roles.FirstOrDefaultAsync(x => x.Name == roleName);
            var temp = findrole.Result;
            ApplicationRole result = (ApplicationRole)temp;
            return Task<ApplicationRole>.FromResult<ApplicationRole>(result);
        }

        public Task UpdateAsync(ApplicationRole role)
        {
            db.Roles.Find(role.Id).Name = role.Name;
            return db.SaveChangesAsync();
        }
    }
}
