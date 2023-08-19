namespace API.Models;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Metric> Metrics { get; set; } = new();

}
