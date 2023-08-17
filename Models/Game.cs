using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Game
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }

    public ICollection<Event>? Events { get; set;}
}
