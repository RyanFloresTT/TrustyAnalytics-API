using API.Models;
using Microsoft.EntityFrameworkCore;

namespace TrustyAnalytics.Models;

public class EventContext : DbContext
{
    public EventContext(DbContextOptions<EventContext> options)
    : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>().ToTable("Event");
    }

    public DbSet<Event> Events { get; set; } = null!;
}