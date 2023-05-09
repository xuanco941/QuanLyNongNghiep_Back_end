
using QuanLyNongNghiepAPI.Models;

namespace QuanLyNongNghiepAPI.Services.Area
{
    public class AreaService : IAreaService
    {
        private readonly DatabaseContext _dbContext;

        public AreaService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        




    }
}
