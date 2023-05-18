using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.AreaDTOs;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.SystemDTOs;
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

        public async Task<bool> Add(AddSystemModel addSystemModel)
        {
            try
            {
                Models.System obj = new Models.System();
                obj.Name = addSystemModel.Name;
                obj.Description = addSystemModel.Description;
                obj.Symbol = addSystemModel.Symbol;
                obj.Address = addSystemModel.Address;
                obj.Location = addSystemModel.Location;
                obj.AreaID = addSystemModel.AreaID;

                await _dbContext.Systems.AddAsync(obj);
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

        public async Task<bool> Delete(GetOrDeleteAreaModel getOrDeleteAreaModel)
        {
            var area = await _dbContext.Areas.FindAsync(getOrDeleteAreaModel.AreaID);
            if (area != null)
            {
                _dbContext.Areas.Remove(area);
            }
            return await _dbContext.SaveChangesAsync() > 0;

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



    }
}
