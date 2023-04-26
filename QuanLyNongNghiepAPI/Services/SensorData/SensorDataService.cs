using QuanLyNongNghiepAPI.Models;

namespace QuanLyNongNghiepAPI.Services.SensorData
{
    public class SensorDataService : ISensorDataService
    {
        private readonly DatabaseContext _dbContext;

        public SensorDataService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
