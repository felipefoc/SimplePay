using SimplePay.DTOs;
using SimplePay.Models;

namespace SimplePay.Repository;

public interface IShopkeeperRepository
{
    Task<Shopkeeper?> GetByIdAsync(Guid id);
    Task<IEnumerable<Shopkeeper>> GetAllAsync();
    Task AddAsync(Shopkeeper shopkeeper);
    void PartiallyUpdate(Shopkeeper shopkeeper, ShopkeeperUpdateDto shopkeeperDto);
    void Update(Shopkeeper shopkeeper);
    void Remove(Shopkeeper shopkeeper);
    Task<int> SaveChangesAsync();
}