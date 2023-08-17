using System.ComponentModel.DataAnnotations;

namespace API.Models;
public class Event
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public Game? Game { get; set;}
    public ICollection<Analytic>? Analytics {get; set;}
}
