using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class CreateGameDto
(
    [Required]
    [StringLength(50)]
    string Title,

    [Required]
    int GenreId,

    [Required]
    [Range(0, 200)]
    decimal Price,

    [Required]
    [StringLength(50)]
    string Developer,

    [Required]
    [StringLength(50)]
    string Publisher,

    DateOnly? ReleaseDate
);

