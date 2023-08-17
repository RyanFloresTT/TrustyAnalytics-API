using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace API.Models;
public class GameAnalyticContext : DbContext
{
    public GameAnalyticContext(DbContextOptions<GameAnalyticContext> options)
        : base(options)
    {
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Metric> Metrics { get; set; }
    public DbSet<MetricValue> MetricValues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Metric>().ToTable("Analytic");
        modelBuilder.Entity<MetricValue>().ToTable("Event");
        modelBuilder.Entity<Game>().ToTable("Game");
        modelBuilder.Entity<Player>().ToTable("Player");

        modelBuilder.Entity<Metric>()
        .HasOne(m => m.Game)
        .WithMany(g => g.Metrics)
        .HasForeignKey(m => m.GameId)
        .IsRequired();
    }
}