namespace API.Models;
public class Analytic
{
    public int AnalyticId { get; set; }
    public int EventId { get; set; }
    public DateTime Timestamp { get; set; }
    public double Value { get; set; }
}