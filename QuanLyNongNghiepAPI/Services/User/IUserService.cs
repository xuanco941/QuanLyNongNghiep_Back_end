namespace QuanLyNongNghiepAPI.Services.User
{
    public interface IUserService
    {
        public Task<List<Models.User>>? GetAllUserAsync();
    }
}
