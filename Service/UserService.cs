using SimplePay.DTOs;
using SimplePay.Models;
using SimplePay.Repository;

namespace SimplePay.Service;

public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<User?> GetUserAsync(Guid id)
    {
        return await userRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<User?>> GetAllUserAsync()
    {
        return await userRepository.GetAllAsync();
    }

    public async Task<User> CreateUserAsync(UserDto userDto)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = userDto.Email,
            FullName = userDto.FullName,
            Cpf = userDto.Cpf,
            Password = userDto.Password,
            Balance = userDto.Balance
        };

        await userRepository.AddAsync(user);
        await userRepository.SaveChangesAsync();
        return user;
    }

    public async Task PartiallyUpdateUserAsync(Guid id, UserUpdateDto userUpdateDto)
    {
        var user = await userRepository.GetByIdAsync(id);
        if (user == null) return;
        userRepository.PartiallyUpdate(user, userUpdateDto);
        await userRepository.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await userRepository.GetByIdAsync(id);
        if (user != null)
        {
            userRepository.Remove(user);
            await userRepository.SaveChangesAsync();
        }
    }
    
}