using System;
using System.Collections.Generic;

namespace Levelup.WebService.Models
{
    // Models returned by AccountController actions.

    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        public string Email { get; set; }
        public string RedirectUrl { get; set; }
    }

    public class ResetPasswordViewModel
    {
        public string Code { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        
    }

    public class ConfirmationViewModel
    {
        public string Id { get; set; }

        public string Token { get; set; }
    }
    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Email { get; set; }
        
        public string UserName { get; set; }

        public bool IsAdmin { get; set; }

        public string FullName { get; set; }
    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
