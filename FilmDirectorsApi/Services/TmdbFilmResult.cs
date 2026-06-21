namespace FilmDirectorsApi.Services;

public class TmdbFilmResult
{
    public string Title { get; set; } = string.Empty;
    public string Overview { get; set; } = string.Empty;
    public string? PosterPath { get; set; }
    public double VoteAverage { get; set; }
    public List<TmdbCastMember> Cast { get; set; } = new();
}

public class TmdbCastMember
{
    public string Name { get; set; } = string.Empty;
    public string Character { get; set; } = string.Empty;
}