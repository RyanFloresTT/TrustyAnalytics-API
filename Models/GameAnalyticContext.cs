using Microsoft.EntityFrameworkCore;
namespace API.Models;
public class GameAnalyticContext : DbContext
{
    public GameAnalyticContext(DbContextOptions<GameAnalyticContext> options)
        : base(options)
    {
    }

    public DbSet<Analytic> Analytics { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Analytic>().ToTable("Analytic");
        modelBuilder.Entity<Event>().ToTable("Event");
        modelBuilder.Entity<Game>().ToTable("Game");
    }
}