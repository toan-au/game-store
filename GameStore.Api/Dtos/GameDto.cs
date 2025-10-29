namespace GameStore.Api.Dtos;

public record class GameDto
(
    int id,
    string title,
    string genre,
    decimal price,
    string developer,
    string publisher,
    DateOnly? releaseDate
);

