using RestSharp;

namespace BusBoard
{

    public class PostCodeClient : APIClient
    {
        // public static RestClient Client { get; set; } //= new RestClient("https://api.postcodes.io/");

        public PostCodeClient()
        {
            Client = new RestClient("https://api.postcodes.io/");            
        }
      
        public  async Task<Coordinates> GetPostCodeCoordinates(string postCode)
        {            
            RestRequest request = new($"postcodes/{postCode}");
            // string url = "https://api.postcodes.io/";
            var response = await APIClient.GetAPIResponse<Coordinates>(request);
            return response;
        }

    }
}