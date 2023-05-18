
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.SystemDTOs;
using QuanLyNongNghiepAPI.DataTransferObject.ServerToClient;

namespace QuanLyNongNghiepAPI.Services.System
{
    public interface ISystemService
    {
        public Task<bool> Add(AddSystemModel addSystemModel);
        public Task<bool> Update(UpdateSystemModel updateSystemModel);
        public Task<bool> Delete(DeleteSystemModel getOrDeleteSystemModel);
        public Task<List<Models.System>?> GetSystemsByUserIDAndAreaID(int userId, int areaId);
        public Task<Models.System?> Get(int Id);
        public Task<PaginatedListModel<Models.System>> GetSystems(int pageNumber, int pageSize);
        public Task<PaginatedListModel<Models.System>> GetSystemsByAreaId(int pageNumber, int pageSize, int areaId);



    }
}
