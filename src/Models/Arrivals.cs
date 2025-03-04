namespace BusBoard
{
    public class Arrivals
    {
        public required string StationName { get; set; }
        public required string DestinationName { get; set; }
        public required int TimeToStation { get; set; }
    }
}