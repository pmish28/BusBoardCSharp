using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using RestSharp;

namespace BusBoard
{

    class TflClient : IAPIClient
    {
        public static RestClient Client { get; set; } 

        public async static Task<List<Arrivals>> GetStopArrivals(string stopCode)
        {
            RestRequest request = new($"{stopCode}/Arrivals");
            string url = "https://api.tfl.gov.uk/StopPoint/";
            var response = await IAPIClient.GetAPIResponse<List<Arrivals>>(request, url);
            return response;
        }
    }
}