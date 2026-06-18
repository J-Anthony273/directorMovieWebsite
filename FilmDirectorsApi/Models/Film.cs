namespace FilmDirectorsApi.Models;
public class Film {
    public int Id {get; set; }
    public string Title {get; set; } = string.Empty;
    public int ReleaseYear {get; set; } 
    public int TmdbId {get; set; }
    public int DirectorId {get; set;}
    public Director Director{get; set; }= null!;
}