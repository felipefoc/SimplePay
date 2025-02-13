using SimplePay.DTOs;
using SimplePay.Models;
using SimplePay.Repository;

namespace SimplePay.Service;

public class ShopkeeperService(IShopkeeperRepository shopkeeperRepository) : IShopkeeperService
{
    public async Task<Shopkeeper?> GetShopkeeperAsync(Guid id)
    {
        return await shopkeeperRepository.GetByIdAsync(id);
    }
    
    public async Task<IEnumerable<Shopkeeper?>> GetAllShopkeeperAsync()
    {
        return await shopkeeperRepository.GetAllAsync();
    }
    
    public async Task<Shopkeeper> CreateShopkeeperAsync(ShopkeeperDto shopkeeperDto)
    {
        var shopkeeper = new Shopkeeper
        {
            Id = Guid.NewGuid(),
            Email = shopkeeperDto.Email,
            FullName = shopkeeperDto.FullName,
            Cnpj = shopkeeperDto.Cnpj,
            Password = shopkeeperDto.Password,
            Balance = shopkeeperDto.Balance
        };

        await shopkeeperRepository.AddAsync(shopkeeper);
        await shopkeeperRepository.SaveChangesAsync();
        return shopkeeper;
    }
    
    public async Task PartiallyUpdateShopkeeperAsync(Guid id, ShopkeeperUpdateDto shopkeeperUpdateDto)
    {
        var shopkeeper = await shopkeeperRepository.GetByIdAsync(id);
        if (shopkeeper == null) return;
        shopkeeperRepository.PartiallyUpdate(shopkeeper, shopkeeperUpdateDto);
        await shopkeeperRepository.SaveChangesAsync();
    }
    
    public async Task DeleteShopkeeperAsync(Guid id)
    {
        var shopkeeper = await shopkeeperRepository.GetByIdAsync(id);
        if (shopkeeper != null)
        {
            shopkeeperRepository.Remove(shopkeeper);
            await shopkeeperRepository.SaveChangesAsync();
        }
    }
}