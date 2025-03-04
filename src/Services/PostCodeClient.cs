using RestSharp;

namespace BusBoard
{

    public class PostCodeClient : APIClient
    {
        public PostCodeClient()
        {
            Client = new RestClient("https://api.postcodes.io/");            
        }
      
        public async Task<Coordinates> GetPostCodeCoordinates(string postCode)
        {            
            RestRequest request = new($"postcodes/{postCode}");
            var response = await APIClient.GetAPIResponse<Coordinates>(request);
            return response;
        }

    }
}