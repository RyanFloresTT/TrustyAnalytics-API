using System.ComponentModel.DataAnnotations;

namespace API.Models;
public class Metric
{
    public int Id { get; set; }
    public string MetricName { get; set; }
    public int?  GameId { get; set; }
    public Game? Game { get; set; }
}