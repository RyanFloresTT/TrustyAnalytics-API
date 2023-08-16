using API.Models;
using Microsoft.EntityFrameworkCore;

namespace TrustyAnalytics.Models;

public class AnalyticContext : DbContext
{
    public AnalyticContext(DbContextOptions<AnalyticContext> options)
    : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Analytic>().ToTable("Analytic");
    }

    public DbSet<Analytic> Analytics { get; set; } = null!;
}