using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using RestSharp;

namespace BusBoard{
    public interface IAPIClient{

        public static RestClient Client { get; set; }
        
        static async Task<T> GetAPIResponse<T>(RestRequest request, string url){

            Client = new(new RestClientOptions(url));
            var response = await Client.GetAsync<T>(request);
            if (response == null)
            {
                throw new Exception("Tfl API error: Not found");
            }
            return response;
        }

    }
    
}