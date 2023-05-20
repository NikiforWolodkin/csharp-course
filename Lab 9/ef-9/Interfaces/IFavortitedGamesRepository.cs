using EF.Entities;

namespace EF.Interfaces
{
    public interface IFavortitedGamesRepository
    {
        Task<ICollection<Game>> GetUserFavoritedGames(Guid userId);
        void AddUserFavoriteGame(Guid userId, Guid gameId);
    }
}
