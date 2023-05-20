using EF.Entities;

namespace EF.Interfaces
{
    public interface IUserRepository
    {
        User AddUser(User user);
        Task<ICollection<User>> GetUsersAsync();
        Task<User> GetUserAsync(Guid id);
        Task DeleteUserAsync(Guid id);
        Task UpdateDatabaseAsync();
    }
}
