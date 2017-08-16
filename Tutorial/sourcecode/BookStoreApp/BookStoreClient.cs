using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BookStoreApp.Model;
using Newtonsoft.Json;
using RestSharp;

namespace BookStoreApp
{
    public class BookStoreClient
    {
        private const string EndPoint = "https://www.googleapis.com/books/v1/volumes?";

        private bool IsSuccessStatusCode(IRestResponse response)
        {
            return response.StatusCode >= HttpStatusCode.OK && response.StatusCode <= (HttpStatusCode)299;
        }

        public BookResult GetBook( string keyword)
        {
            //https://www.googleapis.com/books/v1/volumes?q=programming
            //url = EndPoint + "q=" + keyword
            var url = $"{EndPoint}q={keyword}";

            var client = new RestClient(url);
            var restRequest = new RestRequest {Method = Method.GET};
            
            var response = client.Get(restRequest);

            var responseText = response.Content;

            if (IsSuccessStatusCode(response))
            {
                var bookResult = JsonConvert.DeserializeObject<BookResult>(responseText);

                return bookResult;
            }

            return null;
        }
    }

    
}
