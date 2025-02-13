using SimplePay.DTOs;
using SimplePay.Models;

namespace SimplePay.Repository;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    void PartiallyUpdate(User user, UserUpdateDto userDto);
    void Update(User user);
    void Remove(User user);
    Task<int> SaveChangesAsync();
}