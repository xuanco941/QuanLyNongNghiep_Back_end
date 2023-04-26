using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.DataTransferObject.SensorDTOs;
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

        public async Task<bool> AddSensor(int userId, AddSensorModel addSensorModel){
            try
            {
                var existingGateway = await _dbContext.Gateways.Include(a => a.Category).FirstOrDefaultAsync(a => a.GatewayID == addSensorModel.GatewayID && a.Category.UserID == userId);
                if (existingGateway == null)
                {
                    return false;
                }

                Models.Sensor sensor = new Models.Sensor();
                sensor.Address = addSensorModel.Address;
                sensor.Description = addSensorModel.Description;
                sensor.GatewayID = addSensorModel.GatewayID;
                sensor.Name = addSensorModel.Name;
                sensor.Unit = addSensorModel.Unit;
                sensor.Symbol = addSensorModel.Symbol;

                await _dbContext.Sensors.AddAsync(sensor);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> UpdateSensor(int userId, UpdateSensorModel updateSensor)
        {
            try
            {
                var existingSensor = await _dbContext.Sensors.Include(g => g.Gateway).ThenInclude(g => g.Category).FirstOrDefaultAsync(a => a.SensorID == updateSensor.SensorID && a.Gateway.Category.UserID == userId);
                if (existingSensor == null)
                {
                    return false;
                }

                existingSensor.Name = updateSensor.Name;
                existingSensor.Symbol = updateSensor.Symbol;
                existingSensor.Unit =updateSensor.Unit;
                existingSensor.Address = updateSensor.Address;
                existingSensor.Description = updateSensor.Description;

                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteSensor(int userId, DeleteSensorModel deleteSensorModel)
        {
            try
            {
                var existingSensor = await _dbContext.Sensors.Include(g => g.Gateway).ThenInclude(g => g.Category).FirstOrDefaultAsync(a => a.SensorID == deleteSensorModel.SensorID && a.Gateway.Category.UserID == userId);
                if (existingSensor == null)
                {
                    return false;
                }

                _dbContext.Sensors.Remove(existingSensor);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<Models.Sensor>?> GetSensors(int userId, int gatewayId)
        {
            try
            {
                var obj = await _dbContext.Sensors.Include(g => g.Gateway).ThenInclude(g => g.Category).Where(a => a.GatewayID == gatewayId && a.Gateway.Category.User.UserID == userId).ToListAsync();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
        }
        public async Task<Models.Sensor?> GetASensor(int userId, int sensorId)
        {
            try
            {
                var obj = await _dbContext.Sensors.Include(g => g.Gateway).ThenInclude(g => g.Category).Where(a => a.SensorID == sensorId && a.Gateway.Category.UserID == userId).FirstOrDefaultAsync();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
        }
    }
}
