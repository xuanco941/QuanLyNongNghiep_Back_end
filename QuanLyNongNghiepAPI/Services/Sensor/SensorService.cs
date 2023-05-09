using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.Models;

namespace QuanLyNongNghiepAPI.Services.Sensor
{
    public class SensorService : ISensorService
    {
        private readonly DatabaseContext _dbContext;

        public SensorService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        
    }
}
