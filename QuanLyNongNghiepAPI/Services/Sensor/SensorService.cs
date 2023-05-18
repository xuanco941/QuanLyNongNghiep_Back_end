using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.SensorDTOs;
using QuanLyNongNghiepAPI.DataTransferObject.ServerToClient;
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

        public async Task<bool> Add(AddSensorModel addSensorModel)
        {
            try
            {
                Models.Sensor obj = new Models.Sensor();
                obj.Name = addSensorModel.Name;
                obj.Description = addSensorModel.Description;
                obj.Symbol = addSensorModel.Symbol;
                obj.Address = addSensorModel.Address;
                obj.Unit = addSensorModel.Unit;
                obj.SystemID = addSensorModel.SystemID;

                await _dbContext.Sensors.AddAsync(obj);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Update(UpdateSensorModel updateSensorModel)
        {
            try
            {
                var obj = await _dbContext.Sensors.FindAsync(updateSensorModel.SensorID);
                if (obj != null)
                {
                    obj.Address = updateSensorModel.Address;
                    obj.Unit = updateSensorModel.Unit;
                    obj.Symbol = updateSensorModel.Symbol;
                    obj.Description = updateSensorModel.Description;
                    obj.Name = updateSensorModel.Name;
                }
                return await _dbContext.SaveChangesAsync() > 0;

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> Delete(DeleteSensorModel deleteModel)
        {
            try
            {
                var obj = await _dbContext.Sensors.FindAsync(deleteModel.SensorID);
                if (obj != null)
                {
                    _dbContext.Sensors.Remove(obj);
                }
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                throw;
            }


        }

        public async Task<Models.Sensor?> Get(int Id)
        {
            try
            {
                var obj = await _dbContext.Sensors.FindAsync(Id);

                return obj;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PaginatedListModel<Models.Sensor>> GetSensorsBySystemId(int pageNumber, int pageSize, int systemId)
        {
            try
            {
                // Tính toán điểm bắt đầu và kết thúc
                int startRow = (pageNumber - 1) * pageSize;

                // Lấy tổng số Area
                int totalRows = await _dbContext.Sensors.Where(s => s.SystemID == systemId).CountAsync();

                // Truy vấn Area theo khoảng cần phân trang
                var obj = await _dbContext.Sensors.Where(s => s.SystemID == systemId).Skip(startRow).Take(pageSize).ToListAsync();

                // Trả về kết quả phân trang
                return new PaginatedListModel<Models.Sensor>(obj, pageNumber, pageSize, totalRows);
            }
            catch
            {
                throw;
            }


        }
    }
}
