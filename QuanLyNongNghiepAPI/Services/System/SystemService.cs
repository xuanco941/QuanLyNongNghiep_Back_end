using QuanLyNongNghiepAPI.Models;

namespace QuanLyNongNghiepAPI.Services.System
{
    public class SystemService : ISystemService
    {
        private readonly DatabaseContext _dbContext;

        public SystemService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

       


    }
}
