using API.Models;
using Microsoft.EntityFrameworkCore;

namespace TrustyAnalytics.Models;

public class TrustyAnalyticContext : DbContext
{
    public TrustyAnalyticContext(DbContextOptions<TrustyAnalyticContext> options)
    : base(options)
    {
    }

    public DbSet<TrustyAnalytic> Analytics { get; set; } = null!;
}