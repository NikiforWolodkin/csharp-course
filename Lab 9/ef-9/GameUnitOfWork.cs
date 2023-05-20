using EF.Entities;
using EF.Interfaces;

namespace EF
{
    public class GameUnitOfWork : IGamesUnitOfWork
    {
        private readonly IUserRepository _userRepository;
        private readonly IGameRepository _gameRepository;
        private readonly IFavortitedGamesRepository _favoritedGamesRepository;
        private readonly DataContext _context;

        public GameUnitOfWork(IUserRepository userRepository, IGameRepository gameRepository,
            IFavortitedGamesRepository favoritedGamesRepository, DataContext context)
        {
            _userRepository = userRepository;
            _gameRepository = gameRepository;
            _favoritedGamesRepository = favoritedGamesRepository;
            _context = context;
        }

        public Game AddGame(string name, string description, DateTime releaseDate)
        {
            Game game = new Game
            {
                Name = name,
                Description = description,
                ReleaseDate = releaseDate
            };

            return _gameRepository.AddGame(game);
        }

        public ICollection<Game> AddGames(IList<Game> games)
        {
            var transaction = _context.Database.BeginTransaction();

            foreach (var game in games)
            {
                _gameRepository.AddGame(game);
            }

            transaction.Commit();

            return games;
        }

        public User AddUser(string email, string name)
        {
            User user = new User
            {
                Email = email,
                Name = name
            };

            return _userRepository.AddUser(user);
        }

        public void AddUserFavoriteGame(Guid userId, Guid gameId)
        {
            _favoritedGamesRepository.AddUserFavoriteGame(userId, gameId);
        }

        public async Task DeleteGameAsync(Guid id)
        {
            await _gameRepository.DeleteGameAsync(id);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        public async Task<Game> GetGameAsync(Guid id)
        {
            return await _gameRepository.GetGameAsync(id);
        }

        public async Task<Game> GetGameAsync(string name, DateTime releaseDate)
        {
            var games = await _gameRepository.GetGamesAsync();

            return games
                .Where(game => game.Name == name && game.ReleaseDate == releaseDate)
                .FirstOrDefault();
        }

        public async Task<ICollection<Game>> GetGamesAsync()
        {
            return await _gameRepository.GetGamesAsync();
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await _userRepository.GetUserAsync(id);
        }

        public async Task<ICollection<Game>> GetUserFavoritedGames(Guid userId)
        {
            return await _favoritedGamesRepository.GetUserFavoritedGames(userId);
        }

        public async Task<ICollection<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<Game> UpdateGameAsync(Guid id, string name, string description, DateTime releaseDate)
        {
            Game game = await _gameRepository.GetGameAsync(id)
                ?? throw new ArgumentNullException("Game not found.");

            game.Name = name;
            game.Description = description;
            game.ReleaseDate = releaseDate;

            return game;
        }

        public async Task<User> UpdateUserAsync(Guid id, string email, string name)
        {
            User user = await _userRepository.GetUserAsync(id) 
                ?? throw new ArgumentNullException("User not found.");

            user.Email = email;
            user.Name = name;

            return user;
        }
    }
}
