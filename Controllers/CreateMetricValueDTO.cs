namespace API.Controllers
{
    public class CreateMetricValueDTO
    {
        public int MetricId { get; set; }
        public int PlayerId { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
