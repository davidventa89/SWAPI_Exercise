using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace SWAPI_Exercise
{
    public class Utility
    {
        public string RestRequest(string url)
        {
            string content = String.Empty;

            var RestClient = new RestClient(url);
            var request = new RestRequest();
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;
            var response = RestClient.ExecuteAsync(request);

            content = response.Result.Content;

            return content;
        }
    }
}
