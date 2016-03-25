using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Net.Mail;
using Levelup.Data.Core;
using System.Web.Configuration;

namespace Levelup.WebService.Services
{
    public class EmailService : IIdentityMessageService
    {
        private static readonly string MyAddress = WebConfigurationManager.AppSettings["EmailAddress"];
        private static readonly string MyPass = WebConfigurationManager.AppSettings["EmailPassword"];
        private static readonly string MyDisplayname = WebConfigurationManager.AppSettings["EmailDisplayName"];
        private static readonly string Host = WebConfigurationManager.AppSettings["EmailHost"];
        private static readonly int Port = Convert.ToInt32(WebConfigurationManager.AppSettings["EmailPort"]);

        public Task SendAsync(IdentityMessage message)
        {
            MailMessage mail = new MailMessage(MyAddress, message.Destination, message.Subject, message.Body);
            SmtpClient client = new SmtpClient(Host, Port)
            {
                Credentials = new NetworkCredential(MyAddress, MyPass),
                EnableSsl = true
            };

            return client.SendMailAsync(mail); 
        }

        public Task SendEmailConfirmationAsync(string address, string id, string code, string redirectUrl)
        {
            SmtpClient client = new SmtpClient(Host, Port)
            {
                Credentials = new NetworkCredential(MyAddress, MyPass),
                EnableSsl = true
            };

            MailMessage message = new MailMessage();

            message.IsBodyHtml = true;
            message.Sender = new MailAddress(MyAddress, MyDisplayname);
            message.To.Add(address);
            message.ReplyToList.Add(MyAddress);
            message.Subject = "Confirmation Email";
            message.From = new MailAddress(MyAddress, MyDisplayname);
            message.CC.Add(MyAddress);


            //New link when we changed redirect to client
            //string link = url + "?id=" + id + "&token=" + code;

            //Old link when we redirect to API
            string link = redirectUrl + "?id=" + id + "&token=" + code;

            message.Body = "To confirm your email please following this <a href='" + link + "'>link</a>" + " if you can't redirect, copy this " + link;

            return client.SendMailAsync(message);
        }

        public Task SendEmailResetPasswordAsync(string address, string code, string url)
        {
            SmtpClient client = new SmtpClient(Host, Port)
            {
                Credentials = new NetworkCredential(MyAddress, MyPass),
                EnableSsl = true
            };

            MailMessage message = new MailMessage();

            message.IsBodyHtml = true;
            message.Sender = new MailAddress(MyAddress, MyDisplayname);
            message.To.Add(address);
            message.ReplyToList.Add(MyAddress);
            message.Subject = "Reset Password";
            message.From = new MailAddress(MyAddress, MyDisplayname);
            message.CC.Add(MyAddress);

            string link = url + "?email=" + address + "&code=" + code;
            message.Body = "To reset your password please following this <a href='" + link + "'>link</a>" + " if you can't redirect, copy this " + link;

            return client.SendMailAsync(message);
        }

    }
}