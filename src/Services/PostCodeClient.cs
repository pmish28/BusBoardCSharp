using RestSharp;

namespace BusBoard
{

    public class PostCodeClient : IAPIClient
    {
        public static RestClient Client { get; set; } //= new RestClient("https://api.postcodes.io/");
      
        public static async Task<Coordinates> GetPostCodeCoordinates(string postCode)
        {            
            RestRequest request = new($"postcodes/{postCode}");
            string url = "https://api.postcodes.io/";
            var response = await IAPIClient.GetAPIResponse<Coordinates>(request,url);
            return response;
        }

    }
}