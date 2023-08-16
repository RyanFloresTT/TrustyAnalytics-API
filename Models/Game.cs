using System.Collections;

namespace API.Models;

public class Game
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public ICollection<Event>? Events { get; set;}
}
