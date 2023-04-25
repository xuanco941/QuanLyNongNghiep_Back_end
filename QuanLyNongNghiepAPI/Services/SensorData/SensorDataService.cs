using QuanLyNongNghiepAPI.Models;

namespace QuanLyNongNghiepAPI.Services.SensorData
{
    public class SensorDataService
    {
        private readonly DatabaseContext _dbContext;

        public SensorDataService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
