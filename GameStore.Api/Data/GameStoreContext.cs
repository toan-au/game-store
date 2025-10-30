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
            new Genre() { id = 1, name = "Action" },
            new Genre() { id = 2, name = "Action" },
            new Genre() { id = 3, name = "Action" },
            new Genre() { id = 4, name = "Action" },
            new Genre() { id = 5, name = "Action" },
            new Genre() { id = 6, name = "Action" }
        ];

        modelBuilder.Entity<Genre>().HasData(

        );
    }
}
