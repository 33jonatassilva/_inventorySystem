using InventorySystem.Models;

namespace InventorySystem.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> AddUserAsync(User user);
    Task<User> GetUserByIdAsync(Guid id);
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User> UpdateUserAsync(User user);
    Task DeleteUserAsync(User user);

}