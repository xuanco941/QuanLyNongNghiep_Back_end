using QuanLyNongNghiepAPI.Models;

namespace QuanLyNongNghiepAPI.Services.Sensor
{
    public class SensorService
    {
        private readonly DatabaseContext _dbContext;

        public SensorService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
