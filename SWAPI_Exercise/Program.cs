using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace SWAPI_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetStarShips();
        }

        public static void GetStarShips()
        {
            string url = "https://swapi.dev/api/";

            var starships = new RestClient(url);
            var request = new RestRequest("starships", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            var response = starships.ExecuteAsync(request);

            string content = response.Result.Content;
            
            dynamic JsonResult = JsonConvert.DeserializeObject(content);

            foreach(var item in JsonResult.results)
            {
                Console.WriteLine("");             
            }
        }
    }
}
