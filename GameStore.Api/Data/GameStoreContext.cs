using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Genre[] genres = [
            new Genre() { Id = 1, Name = "Action" },
            new Genre() { Id = 2, Name = "Fighting" },
            new Genre() { Id = 3, Name = "Roleplaying" },
            new Genre() { Id = 4, Name = "Sports" },
            new Genre() { Id = 5, Name = "Racing" },
            new Genre() { Id = 6, Name = "First Person Shooter" },
            new Genre() { Id = 7, Name = "Adventure" },
            new Genre() { Id = 8, Name = "Gacha" },
            new Genre() { Id = 9, Name = "Third Person Shooter" },
            new Genre() { Id = 10, Name = "VR" }
        ];

        modelBuilder.Entity<Genre>().HasData(genres);
    }
}
