namespace GameStore.Api.Entities;

public class Game
{
    public int Id { get; set; }
    public required string name { get; set; }
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
    public decimal price { get; set; }
    public required string developer { get; set; }
    public string? publisher { get; set; }
    public DateOnly? releaseDate { get; set; }
}
