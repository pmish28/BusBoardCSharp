using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using RestSharp;

namespace BusBoard{
    public interface IAPIClient{

        public static RestClient Client { get; set; }
        
        static async Task<T> GetAPIResponse<T>(RestRequest request, string url){

            Client = new(new RestClientOptions(url));
            var resp = await Client.GetAsync(request);
            var response = await Client.GetAsync<T>(request);
            if (response == null)
            {
                throw new Exception("Error while fetching data from API.");
            }
            return response;
        }
    }    
}