using System.Net;
using Newtonsoft.Json;
using RestApiClientApp.Model;
using RestSharp;

namespace RestApiClientApp
{
    public class BookClient
    {
        private const string EndPoint = "https://www.googleapis.com/books/v1/volumes";
        private bool IsSuccessStatusCode(IRestResponse response)
        {
            return response.StatusCode >= HttpStatusCode.OK && response.StatusCode <= (HttpStatusCode)299;
        }

        public Example GetBooks(string keywork)
        {
            var searchUrl = $"{EndPoint}?q={keywork}";
            var restClient = new RestClient(searchUrl);
            var response = restClient.Get(new GetBooksRestRequest());

            return IsSuccessStatusCode(response) ? JsonConvert.DeserializeObject<Example>(response.Content)  : null ;
        }
    }

    public class GetBooksRestRequest : RestRequest
    {
        public GetBooksRestRequest()
        {
            Method = Method.GET;
        }
    }
}
