namespace ForAirAstana.Domain
{
    public class Flight
    {
        public int Id { get; set; }
        public string Origin { get; set; } = String.Empty;
        public string Destination { get; set; } = String.Empty;
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public Status Status { get; set; }
    }
}