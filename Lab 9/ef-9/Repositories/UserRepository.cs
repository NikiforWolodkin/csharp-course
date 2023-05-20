using EF.Entities;
using EF.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();

            return user;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            User user = await _context.Users.FirstAsync(user => user.Id == id);

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<ICollection<User>> GetUsersAsync()
        {
            // return await _context.Users.ToListAsync();

            return await _context.Users
                .FromSql($"SELECT * FROM Users")
                .ToListAsync();
        }

        public async Task UpdateDatabaseAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
