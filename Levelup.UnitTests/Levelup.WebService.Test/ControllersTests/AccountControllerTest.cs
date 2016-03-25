using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Levelup.WebService.Controllers;
using Levelup.WebService;
using Moq;
using Microsoft.AspNet.Identity.EntityFramework;
using Levelup.Data.Core;
using Levelup.DAL.Context;
using Microsoft.Owin.Security;
using Levelup.WebService.Models;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Levelup.UnitTests.Levelup.WebService.Test.ControllersTests
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void RegisterTest()
        {
            var users = new Mock<IDbSet<ApplicationUser>>();

            var ctx = new Mock<ApplicationDbContext>();
            ctx.Setup(m => m.Users).Returns(users.Object);

            var us = new UserStore<ApplicationUser>(ctx.Object);//new Mock<UserStore<ApplicationUser>>(ctx.Object);
            

            RegisterBindingModel fakeModel = new RegisterBindingModel
            {
                Email = "mail@mail.com",
                Password = "qwe123",
                ConfirmPassword = "qwe123"
            };
            var fakeuser = new ApplicationUser()
            {
                Email = fakeModel.Email
            };

            var umng = new ApplicationUserManager(us);//new Mock<ApplicationUserManager>(us.Object);
            //umng.Setup(m => m.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(fakeuser));

            var tknFormat = new Mock<ISecureDataFormat<AuthenticationTicket>>();
            AccountController con = new AccountController(umng, tknFormat.Object);//(umng.Object, tknFormat.Object);

            var regResult = con.Register(fakeModel);

            users.Verify(m => m.Add(It.Is<ApplicationUser>(u => u.Email == fakeuser.Email)), Times.Once());
            //ctx.Verify(m => m.Users.Add(fakeuser), Times.Once());
            //Assert.AreEqual(fakeuser, ctx.Object.Users.FirstOrDefault()/*umng.FindByEmailAsync(fakeModel.Email).Result*/, "damn");
        }
    }
}
