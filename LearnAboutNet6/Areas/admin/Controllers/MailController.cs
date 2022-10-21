using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using LearnAboutNet6.Models;

namespace LearnAboutNet6.Areas.admin.Controllers
{
    [Area("Admin")]
    public class MailController : BaseController
    {
        private readonly IConfiguration configuration;
        public MailController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Index(MailRequest mail)
        {
            var isSend = SendMail(mail.Title, mail.Body, mail.Email);
            if (isSend)
            {
                ViewBag.Message = "Send mail thành công";
            }
            else
            {
                ViewBag.Message = "Send mail thất bại";
            }
             return View();
        }
        private bool SendMail(string Subject, string htmlString, string email)
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("support@3steam.net");
                message.To.Add(new MailAddress(email));
                message.Subject = Subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.Host = "smtp.gmail.com";//for gmail host  
                smtp.Host = configuration["MailSettings:Host"]; //for office 365 host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(configuration["MailSettings:Username"], configuration["MailSettings:Password"]);
                smtp.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
