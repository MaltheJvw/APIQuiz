using Newtonsoft.Json;
using RestSharp;
using System.Security.Cryptography.X509Certificates;

namespace APIQuiz
{
    public class ApiHandler
    {
        public string GetApiResponse(string difficulty = "Easy", string limit = "10", string category = "Code")

        {

            // Set the url for the API that we want to call

            RestClient client = new("https://quizapi.io/api/v1/questions");

            // Create a request to the API

            RestRequest request = new();



            // Add parameters to the request

            request.AddParameter("apiKey", "EUZIEdc24lyiDcE1tuTKN60VjhVBdhBOmgJ9YcGT"); // Add my API-Key

            request.AddParameter("limit", limit); // Set the limit of questions

            request.AddParameter("difficulty", difficulty); // Set the difficulty

            request.AddParameter("category", category); // Set the category



            return client.Execute(request).Content; // Return the response content from the API

        }




        public List<Format> ConvertApi(string category, string limit, string difficulty)

        {
           
            Console.WriteLine($"Kategori: [{category}] Antal spørgsmål: [{limit}] Sværhedsgrad: [{difficulty}]");

            // Convert the response to a list of Format objects by deserializing the JSON-response

            return JsonConvert.DeserializeObject<List<Format>>(GetApiResponse(difficulty, limit, category));

        }
    }
}
