namespace FilmDirectorsApi.DTOs;

public class DirectorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public int TmdbPersonId { get; set; }
    public List<FilmDto> Films { get; set; } = new();
}