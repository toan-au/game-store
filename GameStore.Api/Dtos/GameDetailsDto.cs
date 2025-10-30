namespace GameStore.Api.Dtos;

public record class GameDetailsDto
(
    int Id,
    string Title,
    int GenreId,
    string Genre,
    decimal Price,
    string Developer,
    string? Publisher,
    DateOnly? ReleaseDate
);

