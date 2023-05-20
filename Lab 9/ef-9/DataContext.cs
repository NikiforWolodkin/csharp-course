using EF.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace EF
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<FavoritedGame> Favorites { get; set; }

        public DataContext() : base() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavoritedGame>()
                .HasKey(c => new { c.GameId, c.UserId});
            modelBuilder.Entity<FavoritedGame>()
                .HasOne(c => c.Game)
                .WithMany(f => f.FavoritedGames)
                .HasForeignKey(c => c.GameId);
            modelBuilder.Entity<FavoritedGame>()
                .HasOne(c => c.User)
                .WithMany(u => u.FavoritedGames)
                .HasForeignKey(c => c.UserId);
        }
    }
}
