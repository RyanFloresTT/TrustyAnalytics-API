namespace API.Models;
public class MetricValue
{
    public int Id { get; set; }
    public int MetricId { get; set; }
    public int PlayerId { get; set; }
    public double Value { get; set; }
    public DateTime Timestamp { get; set; }
    public Metric Metric { get; set; }
    public Player Player { get; set; }
}
