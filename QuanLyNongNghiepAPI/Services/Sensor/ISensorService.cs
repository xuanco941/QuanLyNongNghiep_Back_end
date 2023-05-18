
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.SensorDTOs;
using QuanLyNongNghiepAPI.DataTransferObject.ServerToClient;

namespace QuanLyNongNghiepAPI.Services.Sensor
{
    public interface ISensorService
    {
        public Task<bool> Add(AddSensorModel addSensorModel);
        public Task<bool> Update(UpdateSensorModel updateSensorModel);
        public Task<bool> Delete(DeleteSensorModel deleteModel);
        public Task<Models.Sensor?> Get(int Id);
        public Task<PaginatedListModel<Models.Sensor>> GetSensorsBySystemId(int pageNumber, int pageSize, int systemId);

    }
}
