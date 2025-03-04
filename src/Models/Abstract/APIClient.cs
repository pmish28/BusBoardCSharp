using RestSharp;

namespace BusBoard
{

    public abstract class APIClient
    {
        public static RestClient Client { get; set; }

        public static async Task<T> GetAPIResponse<T>(RestRequest request)
        {
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