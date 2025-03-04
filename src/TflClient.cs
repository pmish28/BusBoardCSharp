using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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

    public static async Task<Coordinates> GetPostCodeCoordinates()
    {
        // string url = "https://api.postcodes.io/postcodes/";
        string postCode = "nw51tl";
        RestClient client = new(new RestClientOptions("https://api.postcodes.io/"));
        RestRequest request = new($"postcodes/{postCode}");
        var response = await client.GetAsync<Coordinates>(request);
        // Console.WriteLine(response);
        if(response == null)
        {
            // var cont = response.Content;            
            throw new Exception("Tfl API error: Not found");
        }
        return response;
        // var response = await GetAPIResponse(url,request);
        // return response;
    }


    public static async Task<List<IAPIResponse>> GetAPIResponse(string url, RestRequest request){
        RestClient client = new(new RestClientOptions(url));
        var response = await client.GetAsync<List<IAPIResponse>>(request);
        if(response == null)
        {
            throw new Exception("Tfl API error: Not found");
        }
        return response;
    }

}
}