namespace BusBoard{

    public class NearestStopPointsResponse{
         public List<StopPointInformation>? StopPoints { get; set; }
    }

    public class StopPointInformation{
        public string? Id { get; set; }
        public string? CommonName{get; set;}
    }
}