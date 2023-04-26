using Microsoft.EntityFrameworkCore;
using QuanLyNongNghiepAPI.DataTransferObject.CategoryDTOs;
using QuanLyNongNghiepAPI.DataTransferObject.GatewayDTOs;
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

        public async Task<bool> AddGateway(int userId, AddGatewayModel addGateway)
        {
            try
            {
                var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(a => a.CategoryID == addGateway.CategoryID && a.UserID == userId);
                if (existingCategory == null)
                {
                    return false;
                }

                Models.Gateway gateway = new Models.Gateway();
                gateway.Address = addGateway.Address;
                gateway.CategoryID = addGateway.CategoryID;
                gateway.Location = addGateway.Location;
                gateway.Description = addGateway.Description;
                gateway.Name = addGateway.Name;
                gateway.Symbol = addGateway.Symbol;
                await _dbContext.Gateways.AddAsync(gateway);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> UpdateGateway(int userId, UpdateGatewayModel updateGateway)
        {
            try
            {
                var existingGateway = await _dbContext.Gateways.Include(g => g.Category).FirstOrDefaultAsync(a => a.GatewayID == updateGateway.GatewayID);
                if (existingGateway == null || existingGateway.Category.UserID != userId)
                {
                    return false;
                }

                existingGateway.Location = updateGateway.Location;
                existingGateway.Address = updateGateway.Address;
                existingGateway.Description = updateGateway.Description;
                existingGateway.Name = updateGateway.Name;
                existingGateway.Symbol = updateGateway.Symbol;

                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }

        }
        public async Task<bool> DeleteGateway(int userId, DeleteGatewayModel deleteGateway)
        {
            try
            {
                var existingGateway = await _dbContext.Gateways.Include(g => g.Category).FirstOrDefaultAsync(a => a.GatewayID == deleteGateway.GatewayID);
                if (existingGateway == null || existingGateway.Category.UserID != userId)
                {
                    return false;
                }

                _dbContext.Gateways.Remove(existingGateway);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Models.Gateway>?> GetGateways(int userId, int categoryId)
        {
            try
            {
                var obj = await _dbContext.Gateways.Include(g => g.Category).Where(a => a.CategoryID == categoryId && a.Category.UserID == userId).ToListAsync();
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

        public async Task<Models.Gateway?> GetAGateway(int userId, int gatewayId)
        {
            try
            {
                var obj = await _dbContext.Gateways.Include(g => g.Category).Where(a => a.GatewayID == gatewayId && a.Category.UserID == userId).FirstOrDefaultAsync();
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
