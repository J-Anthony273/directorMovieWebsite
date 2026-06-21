namespace FilmDirectorsApi.DTOs;

public class FilmDetailDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
    public string Overview { get; set; } = string.Empty;
    public string? PosterUrl { get; set; }
    public double ImdbScore { get; set; }
    public List<CastMemberDto> Cast { get; set; } = new();
}