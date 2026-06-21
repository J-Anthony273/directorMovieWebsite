namespace FilmDirectorsApi.DTOs;

public class FilmDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
    public int TmdbId { get; set; }
}