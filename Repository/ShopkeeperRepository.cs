using SimplePay.Database;
using SimplePay.Models;
using Microsoft.EntityFrameworkCore;
using SimplePay.DTOs;

namespace SimplePay.Repository;

public class ShopkeeperRepository(AppDbContext context) : IShopkeeperRepository
{
    public async Task<Shopkeeper?> GetByIdAsync(Guid id)
    {
        var shopkeeper = await context.Shopkeepers.FindAsync(id);
        return shopkeeper;
    }

    public async Task<IEnumerable<Shopkeeper>> GetAllAsync()
    {
        return (await context.Shopkeepers.ToListAsync()).Where(shopkeeper => shopkeeper != null);
    }

    public async Task AddAsync(Shopkeeper shopkeeper)
    {
        await context.Shopkeepers.AddAsync(shopkeeper);
    }

    public void Update(Shopkeeper shopkeeper)
    {
        context.Shopkeepers.Update(shopkeeper);
    }
    
    public void PartiallyUpdate(Shopkeeper shopkeeper, ShopkeeperUpdateDto shopkeeperDto)
    {
        var entry = context.Entry(shopkeeper);
    
        foreach (var property in typeof(ShopkeeperUpdateDto).GetProperties())
        {
            var newValue = property.GetValue(shopkeeperDto);
            if (newValue != null)
            {
                entry.Property(property.Name).CurrentValue = newValue;
            }
        }
    
        context.SaveChanges();
    }
    
    public void Remove(Shopkeeper shopkeeper)
    {
        context.Shopkeepers.Remove(shopkeeper);
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}