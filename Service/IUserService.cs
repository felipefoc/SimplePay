using SimplePay.DTOs;
using SimplePay.Models;

namespace SimplePay.Service;

public interface IUserService
{
    Task<User?> GetUserAsync(Guid id);
    Task<IEnumerable<User?>> GetAllUserAsync();
    Task<User> CreateUserAsync(UserDto user);
    Task PartiallyUpdateUserAsync(Guid id, UserUpdateDto user);
    Task DeleteUserAsync(Guid id);
}