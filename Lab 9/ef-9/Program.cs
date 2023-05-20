using EF;
using EF.Entities;
using EF.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

DbContextOptionsBuilder<DataContext> options = new DbContextOptionsBuilder<DataContext>();

options.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

DataContext dataContext = new DataContext(options.Options);

UserRepository userRepository = new UserRepository(dataContext);
GameRepository gameRepository = new GameRepository(dataContext);
FavoritedGamesRepository favoritedGamesRepository = new FavoritedGamesRepository(dataContext);

GameUnitOfWork gameUOW = new GameUnitOfWork(userRepository, gameRepository, favoritedGamesRepository, dataContext);

foreach (var game in await gameUOW.GetGamesAsync())
{
    await gameUOW.DeleteGameAsync(game.Id);
}

foreach (var user in await gameUOW.GetUsersAsync())
{
    await gameUOW.DeleteUserAsync(user.Id);
}

gameUOW.AddGames(new List<Game>
{
    new Game{ Name = "Witcher 2", Description = "Plotva", ReleaseDate = DateTime.Now },
    new Game{ Name = "Witcher 3", Description = "Plotva", ReleaseDate = DateTime.Now },
});

ICollection<Game> games = await gameUOW.GetGamesAsync();

await gameUOW.UpdateGameAsync(games.First().Id, "Witcher 4", "Plotva", DateTime.Now);

gameUOW.AddUser("Mail 1", "User 1");
gameUOW.AddUser("Mail 2", "User 2");

foreach (var game in await gameUOW.GetGamesAsync())
{
    Console.WriteLine(game.Name);
}

foreach (var user in await gameUOW.GetUsersAsync())
{
    Console.WriteLine(user.Name);
}