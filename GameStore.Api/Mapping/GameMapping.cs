using System;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;

namespace GameStore.Api.Mapping;

public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto dto, Genre? genre)
    {
        return new Game
        {
            Title = dto.Title,
            GenreId = dto.GenreId,
            Genre = genre,
            Price = dto.Price,
            Developer = dto.Developer,
            Publisher = dto.Publisher,
            ReleaseDate = dto.ReleaseDate
        };
    }

    public static GameSummaryDto ToSummaryDto(this Game game)
    {
        return new GameSummaryDto(
            game.Id,
            game.Title,
            game.Genre!.Name,
            game.Price,
            game.Developer,
            game.Publisher,
            game.ReleaseDate
        );
    }
    public static GameDetailsDto ToDetailsDto(this Game game)
    {
        return new GameDetailsDto(
            game.Id,
            game.Title,
            game.Genre!.Id,
            game.Genre!.Name,
            game.Price,
            game.Developer,
            game.Publisher,
            game.ReleaseDate
        );
    }

    public static Game toEntity(this UpdateGameDto game)
    {
        return new Game()
        {
            Title = game.Title,
            GenreId = game.GenreId,
            Price = game.Price,
            Developer = game.Developer,
            Publisher = game.Publisher,
            ReleaseDate = game.ReleaseDate
        };
    }
}
