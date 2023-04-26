using QuanLyNongNghiepAPI.DataTransferObject.GatewayDTOs;

namespace QuanLyNongNghiepAPI.Services.Gateway
{
    public interface IGatewayService
    {
        public Task<bool> AddGateway(int userId, AddGatewayModel addGateway);
        public Task<bool> UpdateGateway(int userId, UpdateGatewayModel updateGateway);
        public Task<bool> DeleteGateway(int userId, DeleteGatewayModel deleteGateway);
        public Task<List<Models.Gateway>?> GetGateways(int userId ,int categoryId);
        public Task<Models.Gateway?> GetAGateway(int userId ,int gatewayId);



    }
}
