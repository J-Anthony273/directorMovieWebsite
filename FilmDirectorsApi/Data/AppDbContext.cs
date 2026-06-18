using Microsoft.EntityFrameworkCore;
using FilmDirectorsApi.Models; 

namespace FilmDirectorsApi.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Director> Directors {get; set; }
    public DbSet<Film> Films {get; set; }
}