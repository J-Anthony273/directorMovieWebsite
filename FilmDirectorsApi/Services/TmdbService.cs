using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Identity.Client;
using FilmDirectorsApi.DTOs;

namespace FilmDirectorsApi.Services;

public class TmdbService
{
    private readonly HttpClient _http;
    private readonly string _apiKey;
    private readonly string _baseUrl;

    public TmdbService(HttpClient http, IConfiguration config)
    {
        _http = http;
        _apiKey = config["TmdbSettings:ApiKey"]!;
        _baseUrl = config["TmdbSettings:BaseUrl"]!;
    }

    public async Task<TmdbFilmResult?> GetFilmDetailsAsync(int tmdbId)
    {
        var detailsUrl = $"{_baseUrl}/movie/{tmdbId}?api_key={_apiKey}";
        var creditsUrl = $"{_baseUrl}/movie/{tmdbId}/credits?api_key={_apiKey}";

        var detailsResponse = await _http.GetAsync(detailsUrl);
        var creditsResponse = await _http.GetAsync(creditsUrl);

        if (!detailsResponse.IsSuccessStatusCode) return null;

        var detailsJson = JsonNode.Parse(await detailsResponse.Content.ReadAsStringAsync());
        var creditsJson = JsonNode.Parse(await creditsResponse.Content.ReadAsStringAsync());

        var cast = creditsJson?["cast"]?.AsArray().Take(5).Select(c => new TmdbCastMember
        {
            Name = c?["name"]?.GetValue<string>() ?? "",
            Character = c?["character"]?.GetValue<string>() ?? ""
        }).ToList() ?? new();

        return new TmdbFilmResult
        {
            Title = detailsJson?["title"]?.GetValue<string>() ?? "",
            Overview = detailsJson?["overview"]?.GetValue<string>() ?? "",
            PosterPath = detailsJson?["poster_path"]?.GetValue<string>(),
            VoteAverage = detailsJson?["vote_average"]?.GetValue<double>() ?? 0,
            Cast = cast
        };
    }

    public async Task<List<FilmDto>> GetDirectorFilmsAsync(int tmdbPersonId)
    {
        var url = $"{_baseUrl}/person/{tmdbPersonId}/movie_credits?api_key={_apiKey}";
        var response = await _http.GetAsync(url);

        if (!response.IsSuccessStatusCode) return new();

        var json = JsonNode.Parse(await response.Content.ReadAsStringAsync());

        var films = json?["crew"]?.AsArray()
            .Where(c => c?["job"]?.GetValue<string>() == "Director")
            .Where(c => c?["release_date"]?.GetValue<string>() is string d && d.Length > 0)
            .OrderBy(c => c?["release_date"]?.GetValue<string>())
            .Select(c => new FilmDto
            {
                Id = c?["id"]?.GetValue<int>() ?? 0,
                Title = c?["title"]?.GetValue<string>() ?? "",
                ReleaseYear = int.Parse(c?["release_date"]!.GetValue<string>()![..4]),
                TmdbId = c?["id"]?.GetValue<int>() ?? 0
            }).ToList() ?? new();

        return films;
    }
}