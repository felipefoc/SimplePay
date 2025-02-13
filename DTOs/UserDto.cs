using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SimplePay.DTOs;

public record UserDto(
    [Required][StringLength(150)] string FullName,
    [Required] decimal Cpf,
    [Required][EmailAddress] string Email,
    [Required][StringLength(30)] string Password,
    decimal Balance 
);

public record UserResponseDto(
    Guid Id,
    string FullName,
    decimal Cpf,
    string Email
);

public record UserDetailResponseDto(
    Guid Id,
    string FullName,
    decimal Cpf,
    string Email,
    decimal? Balance
);

public record UserUpdateDto(
    [StringLength(150)] string? FullName,
    decimal? Cpf,
    [EmailAddress] string? Email,
    decimal? Balance
);
