using EF.Entities;

namespace EF.Interfaces
{
    public interface IGamesUnitOfWork
    {
        Game AddGame(string name, string description, DateTime releaseDate);
        ICollection<Game> AddGames(IList<Game> games);
        Task<Game> UpdateGameAsync(Guid id, string name, string description, DateTime releaseDate);
        Task<ICollection<Game>> GetGamesAsync();
        Task<Game> GetGameAsync(Guid id);
        Task<Game> GetGameAsync(string name, DateTime releaseDate);
        Task DeleteGameAsync(Guid id);
        User AddUser(string email, string name);
        void AddUserFavoriteGame(Guid userId, Guid gameId);
        Task<User> UpdateUserAsync(Guid id, string email, string name);
        Task<ICollection<User>> GetUsersAsync();
        Task<User> GetUserAsync(Guid id);
        Task DeleteUserAsync(Guid id);
        Task<ICollection<Game>> GetUserFavoritedGames(Guid userId);
    }
}
