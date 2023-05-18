using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.SystemDTOs;
using QuanLyNongNghiepAPI.DataTransferObject.ServerToClient;
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

        public async Task<bool> Update(UpdateSystemModel updateSystemModel)
        {
            try
            {
                var obj = await _dbContext.Systems.FindAsync(updateSystemModel.SystemID);
                if (obj != null)
                {
                    obj.Address = updateSystemModel.Address;
                    obj.Location = updateSystemModel.Location;
                    obj.Symbol = updateSystemModel.Symbol;
                    obj.AreaID=updateSystemModel.AreaID;
                    obj.Description = updateSystemModel.Description;
                    obj.Name = updateSystemModel.Name;
                    obj.UpdateAt = DateTime.Now;
                }
                return await _dbContext.SaveChangesAsync() > 0;

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> Delete(DeleteSystemModel getOrDeleteSystemModel)
        {
            try
            {
                var obj = await _dbContext.Systems.FindAsync(getOrDeleteSystemModel.SystemID);
                if (obj != null)
                {
                    _dbContext.Systems.Remove(obj);
                }
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }


        }
        public async Task<List<Models.System>?> GetSystemsByUserIDAndAreaID(int userId, int areaId)
        {
            try
            {
                // Tìm UserArea có cùng UserID và AreaID
                var userArea = await _dbContext.UserAreas.FirstOrDefaultAsync(x => x.UserID == userId && x.AreaID == areaId);

                // Lấy danh sách System thuộc Area đó
                var systems = userArea != null ? await _dbContext.Systems.Where(x => x.AreaID == userArea.AreaID).ToListAsync() : null ;

                return systems;
            }
            catch
            {
                throw;
            }
        }
        public async Task<Models.System?> Get(int Id)
        {
            try
            {
                var area = await _dbContext.Systems.FindAsync(Id);

                return area;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PaginatedListModel<Models.System>> GetSystems(int pageNumber, int pageSize)
        {
            try
            {
                // Tính toán điểm bắt đầu và kết thúc
                int startRow = (pageNumber - 1) * pageSize;

                // Lấy tổng số Area
                int totalRows = await _dbContext.Systems.CountAsync();

                // Truy vấn Area theo khoảng cần phân trang
                var areas = await _dbContext.Systems.Skip(startRow).Take(pageSize).ToListAsync();

                // Trả về kết quả phân trang
                return new PaginatedListModel<Models.System>(areas, pageNumber, pageSize, totalRows);
            }
            catch
            {
                throw;
            }


        }


        public async Task<PaginatedListModel<Models.System>> GetSystemsByAreaId(int pageNumber, int pageSize, int areaId)
        {
            try
            {
                // Tính toán điểm bắt đầu và kết thúc
                int startRow = (pageNumber - 1) * pageSize;

                // Lấy tổng số Area
                int totalRows = await _dbContext.Systems.Where(s => s.AreaID == areaId).CountAsync();

                // Truy vấn Area theo khoảng cần phân trang
                var areas = await _dbContext.Systems.Where(s => s.AreaID == areaId).Skip(startRow).Take(pageSize).ToListAsync();

                // Trả về kết quả phân trang
                return new PaginatedListModel<Models.System>(areas, pageNumber, pageSize, totalRows);
            }
            catch
            {
                throw;
            }


        }

    }
}
