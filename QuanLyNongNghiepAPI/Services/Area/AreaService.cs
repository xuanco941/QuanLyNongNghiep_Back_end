
using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.AreaDTOs;
using QuanLyNongNghiepAPI.DataTransferObject.ServerToClient;
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

        public async Task<bool> Add(AddAreaModel addAreaModel)
        {
            try
            {
                Models.Area area = new Models.Area();
                area.Name = addAreaModel.Name;
                area.Description = addAreaModel.Description;
                area.Symbol = addAreaModel.Symbol;

                await _dbContext.Areas.AddAsync(area);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Update(UpdateAreaModel updateAreaModel)
        {
            try
            {
                var existingArea = await _dbContext.Areas.FindAsync(updateAreaModel.AreaID);
                if (existingArea != null)
                {
                    existingArea.Name = updateAreaModel.Name;
                    existingArea.Description = updateAreaModel.Description;
                    existingArea.Symbol = updateAreaModel.Symbol;
                    existingArea.UpdateAt = DateTime.Now;

                }
                return await _dbContext.SaveChangesAsync() > 0;

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> Delete(DeleteAreaModel deleteAreaModel)
        {
            try
            {
                var area = await _dbContext.Areas.FindAsync(deleteAreaModel.AreaID);
                if (area != null)
                {
                    _dbContext.Areas.Remove(area);
                }
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }


        }

        public async Task<List<Models.Area>?> GetAreaByUserID(int userId)
        {
            try
            {
                var areas = await _dbContext.UserAreas
                    .Where(ua => ua.UserID == userId)
                    .Select(ua => ua.Area)
                    .ToListAsync();

                return areas;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Models.Area?> Get(int Id)
        {
            try
            {
                var area = await _dbContext.Areas.FindAsync(Id);

                return area;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PaginatedListModel<Models.Area>> GetAreas(int pageNumber, int pageSize)
        {
            try
            {
                // Tính toán điểm bắt đầu và kết thúc
                int startRow = (pageNumber - 1) * pageSize;

                // Lấy tổng số Area
                int totalRows = await _dbContext.Areas.CountAsync();

                // Truy vấn Area theo khoảng cần phân trang
                var areas = await _dbContext.Areas.Skip(startRow).Take(pageSize).ToListAsync();

                // Trả về kết quả phân trang
                return new PaginatedListModel<Models.Area>(areas, pageNumber, pageSize, totalRows);
            }
            catch
            {
                throw;
            }


        }

    }
}
