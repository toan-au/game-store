namespace GameStore.Api.Dtos;

public record class GameSummaryDto
(
    int Id,
    string Title,
    string Genre,
    decimal Price,
    string Developer,
    string? Publisher,
    DateOnly? ReleaseDate
);

