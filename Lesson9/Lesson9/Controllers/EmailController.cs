using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Lesson9.Controllers
{
    public class EmailController : Controller
    {

        //private readonly IConfiguration _configuration;
        private readonly IOptions<EmailSettings> _emailSettings;

        public EmailController(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public IActionResult Index()
        {

            using (MailMessage mm = new MailMessage(_emailSettings.Value.UserName, "samer_mail_2006@yahoo.com"))
            {
                mm.Subject = "Test GMail";
                mm.Body = "<p>Test GMail</p>";
                mm.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = _emailSettings.Value.Smtp;
                    smtp.EnableSsl = _emailSettings.Value.EnableSsl;
                    NetworkCredential NetworkCred = new NetworkCredential(_emailSettings.Value.UserName, _emailSettings.Value.Password);
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = _emailSettings.Value.Port;
                    smtp.Send(mm);
                    ViewBag.Message = "Email sent.";
                }
            }
            return Ok();
        }
    }
}
