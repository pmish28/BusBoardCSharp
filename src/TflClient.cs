using RestSharp;

namespace BusBoard{

class TflClient{
    private static readonly RestClient client = new(new RestClientOptions("https://api.tfl.gov.uk/StopPoint/"));
    public static async Task<List<Arrivals>> GetStopArrivals(string stopCode){
        RestRequest request = new($"{stopCode}/Arrivals");
        var response = await client.GetAsync<List<Arrivals>>(request);
        if(response == null)
        {
            throw new Exception("Tfl API error: Not found");
        }
        return response;
    }
}
}