namespace FilmDirectorsApi.Models;

public class Director
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Nationality { get; set; } = string.Empty;
    public int TmdbPersonId { get; set; }
    public List<Film> Films { get; set; } = new();
}