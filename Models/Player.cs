using System.ComponentModel.DataAnnotations;

namespace API.Models;
public class Player
    {
    public int Id { get; set; }
    public string Username { get; set; }
    public List<MetricValue> MetricValues { get; set; } = new();
    }
