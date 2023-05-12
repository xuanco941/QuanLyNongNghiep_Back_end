namespace QuanLyNongNghiepAPI.Utils.Email
{
    public interface ISendEmail
    {
        public Task<bool> SendEmailFromGmail(string toEmail, string subject, string body);
    }
}
