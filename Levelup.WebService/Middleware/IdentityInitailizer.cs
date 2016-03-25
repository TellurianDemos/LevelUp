using Levelup.DAL.Context;
using Levelup.Data.Core;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Levelup.WebService.Middleware
{
    public class IdentityInitailizer : OwinMiddleware
    {
        private const string UserRole = "User";
        private const string AdminRole = "Admin";


        public IdentityInitailizer(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            var usermanager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var rolemanager = new ApplicationRoleManager(new ApplicationRoleStore());

            if (!(await rolemanager.RoleExistsAsync(AdminRole)))
            {
                await rolemanager.CreateAsync(new ApplicationRole(AdminRole));
            }
            if (!(await rolemanager.RoleExistsAsync(UserRole)))
            {
                await rolemanager.CreateAsync(new ApplicationRole(UserRole));
            }

            var admins = await usermanager.UsersInRoleExistAsync(AdminRole);
            var users = await usermanager.UsersInRoleExistAsync(UserRole);
            if (admins == false)
            {
                
                //NEED TO IMPLEMENT ADDING OF ADMIN
                IdentityResult result = await usermanager.CreateAsync(new ApplicationUser()
                {
                    Email = "admin1@levelup.com",
                    FullName = "Admin1",
                    UserName = "admin1@levelup.com",
                    RegisterDate = DateTime.UtcNow
                }, "admin123");

                if (result.Succeeded)
                {
                    var admin1 = await usermanager.FindByEmailAsync("admin1@levelup.com");
                    await usermanager.AddToRoleAsync(admin1.Id, AdminRole);
                }
            }
            if (users == false)
            {

                //NEED TO IMPLEMENT ADDING OF ADMIN
                IdentityResult result = await usermanager.CreateAsync(new ApplicationUser()
                {
                    Email = "user1@mail.ru",
                    FullName = "Vasya",
                    UserName = "user1@mail.ru",
                    RegisterDate = DateTime.UtcNow
                }, "vasya123");

                if (result.Succeeded)
                {
                    var user1 = await usermanager.FindByEmailAsync("user1@mail.ru");
                    await usermanager.AddToRoleAsync(user1.Id, UserRole);
                }
            }

            await Next.Invoke(context);
        }
    }
}