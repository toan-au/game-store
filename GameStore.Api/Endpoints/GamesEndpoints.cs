using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoint
{
    private const string GetGameByIdEndPointName = "GetGameById";
    public static WebApplication MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        group.MapGet("/", (GameStoreContext context) =>
            context.Games
                .Include(game => game.Genre)
                .Select(game => game.ToSummaryDto())
                .AsNoTracking());

        group.MapGet("/{id}", async (int id, GameStoreContext context) =>
        {
            Game? game = await context.Games
                                    .Include(game => game.Genre)
                                    .FirstOrDefaultAsync(game => game.Id == id);
            if (game == null) return Results.NotFound();

            return Results.Ok(game.ToDetailsDto());

        })
        .WithName(GetGameByIdEndPointName);

        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext context) =>
        {
            try
            {
                Game game = newGame.ToEntity(context.Genres.Find(newGame.GenreId));

                context.Games.Add(game);
                await context.SaveChangesAsync();

                return Results.CreatedAtRoute(
                    GetGameByIdEndPointName,
                    new { game.Id },
                    game.ToDetailsDto()
                );
            }
            catch (Exception)
            {
                return Results.BadRequest();
            }
        });

        group.MapPut("/{id}", async (int id, UpdateGameDto payload, GameStoreContext context) =>
        {

            Game? game = context.Games.Find(id);
            if (game == null) return Results.NotFound();

            try
            {
                Game updatedGame = payload.toEntity();
                updatedGame.Id = game.Id;

                context.Entry(game).CurrentValues.SetValues(updatedGame);
                await context.SaveChangesAsync();

                return Results.NoContent();
            }
            catch (Exception e)
            {
                return Results.BadRequest(e);
            }

        });

        group.MapDelete("/{id}", async (int id, GameStoreContext context) =>
        {
            context.Games
                .Where(game => game.Id == id)
                .ExecuteDelete();
            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        return app;
    }
}
