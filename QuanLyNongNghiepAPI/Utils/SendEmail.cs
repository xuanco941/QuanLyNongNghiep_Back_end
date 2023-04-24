using QuanLyNongNghiepAPI.Models;
using System.Net;
using System.Net.Mail;

namespace QuanLyNongNghiepAPI.Utils
{
    public class SendEmail
    {
        private readonly IConfiguration _config;

        public SendEmail(IConfiguration config)
        {
            _config = config;
        }

        public bool SendEmailFromGmail(string toEmail)
        {
            string fromEmail = _config["Email:Address"];
            string password = _config["Email:Password"]; ; //app password , 2auth


            MailMessage message = new MailMessage(_config["Email:Address"], toEmail);
            message.Subject = "Test Email";
            message.Body = "This is a test email sent from C#.";


            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential(fromEmail, password);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            try
            {
                smtpClient.Send(message);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
