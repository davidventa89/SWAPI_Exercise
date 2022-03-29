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
            GetStarShipsAndPilots();
        }

        public static void GetStarShipsAndPilots()
        {           
            Utility utility = new Utility();

            var JsonStarshipResult = JsonConvert.DeserializeObject<StarshipRootobject>(utility.RestRequest("https://swapi.dev/api/starships")).results;

            foreach (var item in JsonStarshipResult)
            {
                string pilotName = String.Empty;
                
                if (item.name.Length >= 10)
                {
                    foreach (var pilots in item.pilots)
                    {                           
                        var JsonPilotResult = JsonConvert.DeserializeObject<PersonResult>(utility.RestRequest(pilots)).name;
                        pilotName = string.IsNullOrEmpty(pilotName) ? pilotName + " " + JsonPilotResult : pilotName + ", " + JsonPilotResult;                       
                    }

                    if (string.IsNullOrEmpty(pilotName))
                    {
                        pilotName = "No Name.";
                    }

                    Console.WriteLine("Starship: " + item.name + " - Pilot Name(s): " + pilotName);
                }                
            }
        }
    }
}

