using System.Net;
using System.Net.Mail;

namespace QuanLyNongNghiepAPI.Utils
{
    public class SendEmail : ISendEmail
    {
        private readonly IConfiguration _config;

        public SendEmail(IConfiguration config)
        {
            _config = config;
        }

        public async Task <bool> SendEmailFromGmail(string toEmail, string subject, string body)
        {
            string fromEmail = _config["Email:Address"];
            string password = _config["Email:Password"]; ; //app password , 2auth
            try
            {
                MailMessage message = new MailMessage(fromEmail, toEmail);
                message.Subject = subject;
                message.Body = body;


                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential(fromEmail, password);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                await Task.Run(() => smtpClient.Send(message));
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
