namespace EF.Entities
{
    public class FavoritedGame
    {
        public Guid GameId { get; set; }
        public Guid UserId { get; set; }
        public Game Game { get; set; }
        public User User { get; set; }
    }
}
