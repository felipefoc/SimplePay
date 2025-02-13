using System.ComponentModel.DataAnnotations;

namespace SimplePay.DTOs;

public record ShopkeeperDto(
    [Required][StringLength(150)] string FullName,
    [Required] decimal Cnpj,
    [Required][EmailAddress] string Email,
    [Required][StringLength(30)] string Password,
    decimal Balance 
);

public record ShopkeeperResponseDto(
    Guid Id,
    string FullName,
    decimal Cnpj,
    string Email
);

public record ShopkeeperDetailResponseDto(
    Guid Id,
    string FullName,
    decimal Cnpj,
    string Email,
    decimal? Balance
);

public record ShopkeeperUpdateDto(
    [StringLength(150)] string? FullName,
    decimal? Cnpj,
    [EmailAddress] string? Email,
    decimal? Balance
);