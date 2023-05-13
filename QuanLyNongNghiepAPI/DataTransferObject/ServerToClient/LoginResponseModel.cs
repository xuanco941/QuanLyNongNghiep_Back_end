namespace QuanLyNongNghiepAPI.DataTransferObject.ServerToClient
{
    public class LoginResponseModel<T>
    {
        public string Token { get; set; } = string.Empty;
        public T? Info { get; set; }
    }
}
