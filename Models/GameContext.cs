using API.Models;
using Microsoft.EntityFrameworkCore;

namespace TrustyAnalytics.Models;

public class GameContext : DbContext
{
    public GameContext(DbContextOptions<GameContext> options)
    : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>().ToTable("Game");
    }

    public DbSet<Game> Games { get; set; } = null!;
}