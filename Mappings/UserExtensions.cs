using SimplePay.DTOs;
using SimplePay.Models;

namespace SimplePay.Mappings;

public static class UserExtensions
{
    public static UserResponseDto ToUserResponseDto(this User user)
    {
        return new UserResponseDto(
            Id: user.Id,
            FullName: user.FullName,
            Cpf: user.Cpf,
            Email: user.Email
        );
    }

    public static UserDetailResponseDto ToUserDetailResponseDto(this User user)
    {
        return new UserDetailResponseDto(
            Id: user.Id,
            FullName: user.FullName,
            Cpf: user.Cpf,
            Email: user.Email,
            Balance: user.Balance
        );
    }

    public static Task<IEnumerable<UserResponseDto>> ToUserResponseDtoListAsync(this IEnumerable<User> users)
    {
        return Task.FromResult(users.Select(user => user.ToUserResponseDto()));
    }
}