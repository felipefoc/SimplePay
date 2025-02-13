using SimplePay.DTOs;
using SimplePay.Models;

namespace SimplePay.Mappings;

public static class ShopkeeperExtensions
{
    public static ShopkeeperResponseDto ToShopkeeperResponseDto(this Shopkeeper shopkeeper)
    {
        return new ShopkeeperResponseDto(
            Id: shopkeeper.Id,
            FullName: shopkeeper.FullName,
            Cnpj: shopkeeper.Cnpj,
            Email: shopkeeper.Email
        );
    }
    
    public static ShopkeeperDetailResponseDto ToShopkeeperDetailResponseDto(this Shopkeeper shopkeeper)
    {
        return new ShopkeeperDetailResponseDto(
            Id: shopkeeper.Id,
            FullName: shopkeeper.FullName,
            Cnpj: shopkeeper.Cnpj,
            Email: shopkeeper.Email,
            Balance: shopkeeper.Balance
        );
    }
    
    public static Task<IEnumerable<ShopkeeperResponseDto>> ToShopkeeperResponseDtoListAsync(this IEnumerable<Shopkeeper> shopkeepers)
    {
        return Task.FromResult(shopkeepers.Select(shopkeeper => shopkeeper.ToShopkeeperResponseDto()));
    }
}