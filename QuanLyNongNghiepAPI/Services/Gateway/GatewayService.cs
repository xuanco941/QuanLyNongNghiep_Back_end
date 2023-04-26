using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.Models;

namespace QuanLyNongNghiepAPI.Services.Gateway
{
    public class GatewayService : IGatewayService
    {
        private readonly DatabaseContext _dbContext;

        public GatewayService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddGateway(int userId,Models.Gateway gateway)
        {
            try
            {
                await _dbContext.Gateways.AddAsync(gateway);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> UpdateGateway(Models.Gateway gateway)
        {
            try
            {
                var existingGateway = await _dbContext.Gateways.FindAsync(gateway.GatewayID);
                if (existingGateway != null)
                {
                    existingGateway.Address = gateway.Address;
                    existingGateway.Location = gateway.Location;
                    existingGateway.Name = gateway.Name;
                    existingGateway.Symbol = gateway.Symbol;
                    existingGateway.CreateAt = gateway.CreateAt;
                    return await _dbContext.SaveChangesAsync() > 0;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
        //public async Task<bool> DeleteGateway(int gatewayID, int uid)
        //{
        //    //try
        //    //{
        //    //    var gateway = await _dbContext.Gateways.FindAsync(gatewayID).;
        //    //    if (category != null && category.UserID == uid)
        //    //    {
        //    //        _dbContext.Categories.Remove(category);
        //    //        return await _dbContext.SaveChangesAsync() > 0;
        //    //    }
        //    //    else
        //    //    {
        //    //        return false;
        //    //    }
        //    //}
        //    //catch
        //    //{
        //    //    return false;
        //    //}
        //}
        public async Task<List<Models.Gateway>?> GetGatewayOfACategory(int categoryID)
        {
            try
            {
                var category = await _dbContext.Gateways.Where(c => c.CategoryID == categoryID).ToListAsync();
                if (category != null)
                {
                    return category;
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
