namespace API.Models;
public class Analytic
{
    public int Id {get; set;}
    public DateTime Timestamp { get; set; }
    public double Value { get; set; }

    public Event? Event;
}