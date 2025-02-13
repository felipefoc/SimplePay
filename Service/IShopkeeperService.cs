using SimplePay.DTOs;
using SimplePay.Models;

namespace SimplePay.Service;

public interface IShopkeeperService
{
    Task<Shopkeeper?> GetShopkeeperAsync(Guid id);
    Task<IEnumerable<Shopkeeper?>> GetAllShopkeeperAsync();
    Task<Shopkeeper> CreateShopkeeperAsync(ShopkeeperDto shopkeeper);
    Task PartiallyUpdateShopkeeperAsync(Guid id, ShopkeeperUpdateDto shopkeeper);
    Task DeleteShopkeeperAsync(Guid id);
}