using System.Runtime.CompilerServices;

namespace BusBoard
{
    public class Coordinates
    {
        public required int Status { get; set; }
        public required CoordinatesInformation Result { get; set; }

       
    }

    public class CoordinatesInformation{
        public double Longitude { get; set; }
        public double Latitude {get;set;}
    }

}