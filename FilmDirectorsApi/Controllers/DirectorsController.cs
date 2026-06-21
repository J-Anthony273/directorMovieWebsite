using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FilmDirectorsApi.Data;
using FilmDirectorsApi.DTOs;
using FilmDirectorsApi.Services;

namespace FilmDirectorsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectorsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly TmdbService _tmdb;

    public DirectorsController(AppDbContext context, TmdbService tmdb)
    {
        _context = context;
        _tmdb = tmdb;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var directors = await _context.Directors.ToListAsync();

        var result = directors.Select(d => new DirectorDto
        {
            Id = d.Id,
            Name = d.Name,
            Nationality = d.Nationality,
            TmdbPersonId = d.TmdbPersonId
        }).ToList();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var director = await _context.Directors
            .FirstOrDefaultAsync(d => d.Id == id);

        if (director == null) return NotFound();

        var films = await _tmdb.GetDirectorFilmsAsync(director.TmdbPersonId);

        var result = new DirectorDto
        {
            Id = director.Id,
            Name = director.Name,
            Nationality = director.Nationality,
            TmdbPersonId = director.TmdbPersonId,
            Films = films
        };

        return Ok(result);
    }
}