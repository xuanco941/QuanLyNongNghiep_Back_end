namespace QuanLyNongNghiepAPI.Utils
{
    public interface ISendEmail
    {
        public Task<bool> SendEmailFromGmail(string toEmail, string subject, string body);
    }
}
