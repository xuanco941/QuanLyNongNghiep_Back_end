
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.AreaDTOs;
using QuanLyNongNghiepAPI.DataTransferObject.ServerToClient;

namespace QuanLyNongNghiepAPI.Services.Area
{
    public interface IAreaService
    {
        public Task<bool> Add(AddAreaModel addAreaModel);
        public Task<bool> Update(UpdateAreaModel updateAreaModel);
        public Task<bool> Delete(DeleteAreaModel getOrDeleteAreaModel);
        public Task<Models.Area?> Get(int Id);
        public Task<List<Models.Area>?> GetAreaByUserID(int userId);
        public Task<PaginatedListModel<Models.Area>> GetAreas(int pageNumber, int pageSize);




    }
}
