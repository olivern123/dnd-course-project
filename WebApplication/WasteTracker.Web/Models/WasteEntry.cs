namespace WasteTracker.Web.Models
{
    public class WasteEntry
    {
        public Guid Id { get; set; }
        public string Material { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public double WeightKg { get; set; }
        public string Source { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}