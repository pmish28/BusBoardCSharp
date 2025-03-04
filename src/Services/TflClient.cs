using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using RestSharp;

namespace BusBoard
{

    class TflClient : APIClient
    {
        public TflClient()
        {
            Client = new RestClient("https://api.tfl.gov.uk/StopPoint/");            
        }

        public async Task<List<Arrivals>> GetStopArrivals(string? stopCode)
        {
            RestRequest request = new($"{stopCode}/Arrivals");
            // string url = "https://api.tfl.gov.uk/StopPoint/";
            var response = await APIClient.GetAPIResponse<List<Arrivals>>(request);
            return response;
        }

        public async Task<NearestStopPointsResponse> GetStopPoints(double latitude, double longitude)
        {
            RestRequest request = new($"?lat={latitude}&lon={longitude}&stopTypes=NaptanPublicBusCoachTram&radius=200&modes=bus");
            // string url = "https://api.tfl.gov.uk/StopPoint/";
            var response = await APIClient.GetAPIResponse<NearestStopPointsResponse>(request);            
            return response;
        }
    }
}