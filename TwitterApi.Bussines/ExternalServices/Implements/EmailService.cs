using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web;
using TwitterApi.Core.Entities.Identity;

namespace TwitterApi.Bussines.ExternalServices.Implements
{
    public class EmailService : IEmailService
    {
        IConfiguration _configuration { get; }
        UserManager<AppUser> _um { get; }
        IHttpContextAccessor _context { get; }
        IUrlHelperFactory _url { get; }
        IActionContextAccessor _actionContextAccessor { get; }
        public EmailService(IConfiguration configuration,
            UserManager<AppUser> um,
            IHttpContextAccessor context,
            IActionContextAccessor actionContextAccessor,
            IUrlHelperFactory url)
        {
            _configuration = configuration;
            _um = um;
            _context = context;
            _actionContextAccessor = actionContextAccessor;
            _url = url;
        }


        public async Task SendEmailConfirmedAsync(UserDto user)
        {
            string token = await _um.GenerateEmailConfirmationTokenAsync(_um.FindByIdAsync(user.UserId).Result);
            string link = await CreateLinkAsync("EmailConfirmed", "Users", token, user);
            string template = await EditingEmailConfirmedTemplateAsync(user.UserName, link);
            await SendEmailAsync(template, user.UserName, user.Email);
        }

        public async Task SendForgotPasswordMailAsync(UserDto user, string token)
        {
            string link = await CreateLinkAsync("ResetPassword", "Auths", token, user);
            string template = await EditingEmailConfirmedTemplateAsync(user.UserName, link);
            await SendEmailAsync(template, user.UserName, user.Email);
        }

        async Task SendEmailAsync(string body, string header, string mailAddress, bool isHtml = true)
        {
            SmtpClient smtp = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]));
            smtp.Credentials = new NetworkCredential(_configuration["Email:UserName"], _configuration["Email:Password"]);
            smtp.EnableSsl = true;
            MailAddress from = new MailAddress(_configuration["Email:UserName"], "Twiter");
            MailAddress to = new MailAddress(mailAddress);
            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Subject = header;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = isHtml;
            smtp.Send(mailMessage);
        }


        async Task<string> CreateLinkAsync(string action, string controller, string token, UserDto user)
        {
            var url = _url.GetUrlHelper(_actionContextAccessor.ActionContext);

            string link = url.Action(action, controller, new
            {
                token = HttpUtility.UrlEncode(token),
                userId = user.UserId
            }, _context.HttpContext.Request.Scheme);
            return link;
        }

        async Task<string> EditingEmailConfirmedTemplateAsync(string userName, string url)
        {
            using StreamReader sr = new StreamReader(Path.Combine(PathConstants.RootPath, "schema/confirmEmail.html"));
            string template = sr.ReadToEnd();
            template = template.Replace("[[[userName]]]", userName).Replace("[[[link]]]", url);
            return template;
        }
    }
}
