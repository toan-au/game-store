namespace GameStore.Api.Dtos;

public record class UpdateGameDto
(
    string title,
    string genre,
    decimal price,
    string developer,
    string publisher,
    DateOnly? releaseDate
);
