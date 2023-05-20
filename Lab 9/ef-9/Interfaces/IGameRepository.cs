using EF.Entities;

namespace EF.Interfaces
{
    public interface IGameRepository
    {
        Game AddGame(Game game);
        Task<ICollection<Game>> GetGamesAsync();
        Task<Game> GetGameAsync(Guid id);
        Task DeleteGameAsync(Guid id);
        Task UpdateDatabaseAsync();
    }
}
