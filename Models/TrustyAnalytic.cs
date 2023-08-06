namespace API.Models
{
    public class TrustyAnalytic
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public float OccurenceCount { get; set; }
        public DateTime Time { get; set; }
    }
}
