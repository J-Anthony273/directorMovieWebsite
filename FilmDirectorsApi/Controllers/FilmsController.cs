using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmDirectorsApi.Data;
using FilmDirectorsApi.Services;
using FilmDirectorsApi.DTOs;

namespace FilmDirectorsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly TmdbService _tmdb;

    public FilmsController(AppDbContext context, TmdbService tmdb)
    {
        _context = context;
        _tmdb = tmdb;
    }

    [HttpGet("{tmdbId}")]
    public async Task<IActionResult> GetById(int tmdbId)
    {
        var tmdbDetails = await _tmdb.GetFilmDetailsAsync(tmdbId);

        if (tmdbDetails == null) return StatusCode(502, "Could not fetch film details from TMDb");

        var result = new FilmDetailDto
        {
            Id = tmdbId,
            Title = tmdbDetails.Title,
            Overview = tmdbDetails.Overview,
            PosterUrl = tmdbDetails.PosterPath != null
                ? $"https://image.tmdb.org/t/p/w500{tmdbDetails.PosterPath}"
                : null,
            ImdbScore = Math.Round(tmdbDetails.VoteAverage, 1),
            Cast = tmdbDetails.Cast.Select(c => new CastMemberDto
            {
                Name = c.Name,
                Character = c.Character
            }).ToList()
        };

        return Ok(result);
    }
}