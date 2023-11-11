using RestSharp.Authenticators;
using RestSharp;

namespace Helpers.Classes
{
    public class RestHelper
    {
        private readonly RestClient client;

        public RestHelper(string url, string username, string password)
        {
            var options = new RestClientOptions(url)
            {
                Authenticator = new HttpBasicAuthenticator(username, password)
            };

            client = new RestClient(options);
        }
        public RestResponse DoRequest(Method method, string endpoint, string? body)
        {
            RestRequest request = new RestRequest(endpoint, method);
            if (body != null)
            {
                request.AddParameter("application/json", body, ParameterType.RequestBody);
            }

            try
            {
                return client.Execute(request);
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException("Request failed with the following error: " + e.Message);
            }
        }
    }
}