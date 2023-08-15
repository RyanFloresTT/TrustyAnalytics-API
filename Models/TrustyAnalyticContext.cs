using API.Models;
using Microsoft.EntityFrameworkCore;

namespace TrustyAnalytics.Models;

public class TrustyAnalyticContext : DbContext
{
    public TrustyAnalyticContext(DbContextOptions<TrustyAnalyticContext> options)
    : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Analytic>().ToTable("Analytic");
    }

    public DbSet<Analytic> Analytics { get; set; } = null!;
}