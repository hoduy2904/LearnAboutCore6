using Microsoft.AspNetCore.Html;
using System.Net.Mail;
using System.Net;

namespace LearnAboutNet6.Services
{
    public class MailServices : IMailServices
    {
        private readonly IConfiguration configuration;
        public MailServices(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public bool SendMail(string subject, string body, string email)
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("support@3steam.net");
                message.To.Add(new MailAddress(email));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = body;
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
