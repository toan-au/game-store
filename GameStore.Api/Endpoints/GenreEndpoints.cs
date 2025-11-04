using System;
using GameStore.Api.Data;
using GameStore.Api.Mappings;

namespace GameStore.Api.Endpoints;

public static class GenreEndpoints
{
    public static WebApplication MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres").WithParameterValidation();

        group.MapGet("/", (GameStoreContext context) =>
        {
            return context.Genres.Select(genre => genre.ToDto());
        });

        group.MapPost("/", () =>
        {

        });

        return app;
    }
}
