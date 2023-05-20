using EF;
using EF.Entities;
using EF.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EF.Repositories
{
    public class FavoritedGamesRepository : IFavortitedGamesRepository
    {
        private readonly DataContext _context;

        public FavoritedGamesRepository(DataContext context)
        {
            _context = context;
        }

        public void AddUserFavoriteGame(Guid userId, Guid gameId)
        {
            if (!_context.Users.Any(user => user.Id == userId))
            {
                throw new ArgumentNullException("User not found.");
            }

            if (!_context.Games.Any(game => game.Id == userId))
            {
                throw new ArgumentNullException("Game not found.");
            }

            FavoritedGame favoritedGame = new FavoritedGame()
            {
                UserId = userId,
                GameId = gameId
            };

            _context.Favorites.Add(favoritedGame);
        }

        public async Task<ICollection<Game>> GetUserFavoritedGames(Guid userId)
        {
            return await _context.Favorites
                .Include(fav => fav.Game)
                .Where(fav => fav.UserId == userId)
                .Select(fav => fav.Game)
                .ToListAsync();
        }
    }
}
