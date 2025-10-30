using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record class UpdateGameDto
(
    [Required]
    [StringLength(50)]
    string title,

    [Required]
    [StringLength(20)]
    string genre,

    [Required]
    [Range(0, 200)]
    decimal price,

    [Required]
    [StringLength(50)]
    string developer,

    [Required]
    [StringLength(50)]
    string publisher,

    DateOnly? releaseDate
);
