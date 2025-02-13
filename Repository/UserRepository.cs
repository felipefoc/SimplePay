using Microsoft.EntityFrameworkCore;
using SimplePay.Database;
using SimplePay.DTOs;
using SimplePay.Models;

namespace SimplePay.Repository;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User?> GetByIdAsync(Guid id)
    {
        var user = await context.Users.FindAsync(id);
        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return (await context.Users.ToListAsync()).Where(user => user != null);
    }

    public async Task AddAsync(User user)
    {
        await context.Users.AddAsync(user);
    }

    public void Update(User user)
    {
        context.Users.Update(user);
    }
    
    public void PartiallyUpdate(User user, UserUpdateDto userDto)
    {
        var entry = context.Entry(user);
    
        foreach (var property in typeof(UserUpdateDto).GetProperties())
        {
            var newValue = property.GetValue(userDto);
            if (newValue != null)
            {
                entry.Property(property.Name).CurrentValue = newValue;
            }
        }
    
        context.SaveChanges();
    }
    
    public void Remove(User user)
    {
        context.Users.Remove(user);
    }
    
    public async Task<int> SaveChangesAsync()
    {
       return await context.SaveChangesAsync();
    }
}