using Microsoft.EntityFrameworkCore;
using FilmDirectorsApi.Models; 

namespace FilmDirectorsApi.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Director> Directors {get; set; }
    public DbSet<Film> Films {get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Director>().HasData(
        new Director { Id = 1, Name = "Christopher Nolan", Nationality = "British", TmdbPersonId = 525 },
        new Director { Id = 2, Name = "Martin Scorsese", Nationality = "American", TmdbPersonId = 1032 },
        new Director { Id = 3, Name = "Quentin Tarantino", Nationality = "American", TmdbPersonId = 138 },
        new Director { Id = 4, Name = "Stanley Kubrick", Nationality = "American", TmdbPersonId = 240 },
        new Director { Id = 5, Name = "Steven Spielberg", Nationality = "American", TmdbPersonId = 488 },
        new Director { Id = 6, Name = "David Fincher", Nationality = "American", TmdbPersonId = 7467 },
        new Director { Id = 7, Name = "Alfred Hitchcock", Nationality = "British", TmdbPersonId = 2636 },
        new Director { Id = 8, Name = "Ridley Scott", Nationality = "British", TmdbPersonId = 578 }
    );
    }
}