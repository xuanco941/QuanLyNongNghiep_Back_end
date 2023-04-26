using QuanLyNongNghiepAPI.DataTransferObject.SensorDTOs;

namespace QuanLyNongNghiepAPI.Services.Sensor
{
    public interface ISensorService
    {
        public Task<bool> AddSensor(int userId, AddSensorModel addSensorModel);
        public Task<bool> UpdateSensor(int userId, UpdateSensorModel updateSensor);
        public Task<bool> DeleteSensor(int userId, DeleteSensorModel deleteSensorModel);
        public Task<List<Models.Sensor>?> GetSensors(int userId, int gatewayId);
        public Task<Models.Sensor?> GetASensor(int userId, int sensorId);
    }
}
