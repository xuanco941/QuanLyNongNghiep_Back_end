
using QuanLyNongNghiepAPI.DataTransferObject.ClientToServer.AreaDTOs;

namespace QuanLyNongNghiepAPI.Services.Area
{
    public interface IAreaService
    {
        public Task<bool> Add(AddAreaModel addAreaModel);
        public Task<bool> Update(UpdateAreaModel updateAreaModel);
        public Task<bool> Delete(GetOrDeleteAreaModel getOrDeleteAreaModel);
        public Task<Models.Area?> Get(int Id);
        public Task<List<Models.Area>?> GetAreaByUserID(int userId);



    }
}
