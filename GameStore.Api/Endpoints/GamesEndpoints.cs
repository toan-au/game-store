using System;
using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    private const string GetGameByIdEndPointName = "GetGameById";
    private static readonly List<GameDto> games = new()
    {
        new GameDto(1, "The Witcher 3: Wild Hunt", "RPG", 39.99m, "CD Projekt Red", "CD Projekt", new DateOnly(2015, 5, 19)),
        new GameDto(2, "Cyberpunk 2077", "Action RPG", 59.99m, "CD Projekt Red", "CD Projekt", new DateOnly(2020, 12, 10)),
        new GameDto(3, "God of War", "Action-Adventure", 49.99m, "Santa Monica Studio", "Sony Interactive Entertainment", new DateOnly(2018, 4, 20)),
        new GameDto(4, "Halo Infinite", "First-Person Shooter", 59.99m, "343 Industries", "Xbox Game Studios", new DateOnly(2021, 12, 8)),
        new GameDto(5, "Minecraft", "Sandbox", 26.95m, "Mojang Studios", "Mojang Studios", new DateOnly(2011, 11, 18)),
        new GameDto(6, "Final Fantasy XIV", "MMORPG", 59.99m, "Square Enix", "Square Enix", new DateOnly(2010, 9, 30))
    };

    public static WebApplication MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games");

        group.MapGet("/", () => games);

        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.id == id);
            return game is GameDto dto
                ? Results.Ok(dto)
                : Results.NotFound();
        }).WithName(GetGameByIdEndPointName);

        group.MapPost("/", (CreateGameDto newGame) =>
        {
            try
            {
                int id = games.Count + 1;
                games.Add(new GameDto(
                    id,
                    title: newGame.title,
                    genre: newGame.genre,
                    price: newGame.price,
                    developer: newGame.developer,
                    publisher: newGame.publisher,
                    releaseDate: newGame.releaseDate
                ));
                return Results.CreatedAtRoute(GetGameByIdEndPointName, new { id }, games.Find(game => game.id == id));
            }
            catch (Exception)
            {
                return Results.BadRequest();
            }
        });

        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            int index = games.FindIndex(game => game.id == id);
            if (index == -1) return Results.NotFound();

            games[index] = new GameDto(
                id,
                title: updatedGame.title,
                genre: updatedGame.genre,
                price: updatedGame.price,
                developer: updatedGame.developer,
                publisher: updatedGame.publisher,
                releaseDate: updatedGame.releaseDate
            );
            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.id == id);
            return Results.NoContent();
        });

        return app;
    }
}
