using EF;
using EF.Entities;
using EF.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EF.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly DataContext _context;

        public GameRepository(DataContext context)
        {
            _context = context;
        }

        public Game AddGame(Game game)
        {
            _context.Games.Add(game);

            _context.SaveChanges();

            return game;
        }

        public async Task DeleteGameAsync(Guid id)
        {
            Game game = await _context.Games.FirstAsync(game => game.Id == id);

            _context.Games.Remove(game);

            await _context.SaveChangesAsync();
        }

        public async Task<Game> GetGameAsync(Guid id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<ICollection<Game>> GetGamesAsync()
        {
            return await _context.Games
                .OrderByDescending(game => game.ReleaseDate)
                .ToListAsync();
        }

        public async Task UpdateDatabaseAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
