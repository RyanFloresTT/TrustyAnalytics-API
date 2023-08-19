using Microsoft.EntityFrameworkCore;

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

        modelBuilder.Entity<MetricValue>()
            .HasOne(mv => mv.Metric)
            .WithMany(m => m.MetricValues)
            .HasForeignKey(mv => mv.MetricId)
            .IsRequired();

        modelBuilder.Entity<MetricValue>()
            .HasOne(mv => mv.Player)
            .WithMany(p => p.MetricValues)
            .HasForeignKey(mv => mv.PlayerId)
            .IsRequired();
    }
}