using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Swapi_Testing
{
    class Program
    {
        async static Task Main(string[] args)
        {
            string id = args.Length == 0 ? "1" : args[0];

            var url = @"https://swapi.dev";
            var client = new HttpClient() { BaseAddress = new Uri(url) };
            var result = await client.GetAsync($"api/films/{id}/");
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var film = JsonSerializer.Deserialize<Film>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                Console.WriteLine(film.Title);
                Console.WriteLine();
                Console.WriteLine(film.Director);
                Console.WriteLine();
                Console.WriteLine(film.Opening_crawl);
                Console.WriteLine();
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("No funciona");
            }

            // client.DefaultRequestHeaders.Add("Authentication", "Bearer HFDHUAISHDIUASHDUISAHDUISHAUDHSAUIDHASIUDHASUIDHIAUHDIUHASUID");
            //...>
        }
        
    }
    public class Film
    {
        public string Title { get; set; }
        public int Episode_id { get; set; }
        public string Opening_crawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string Release_date { get; set; }
        public string[] Characters { get; set; }
        public string[] Planets { get; set; }
        public string[] Starships { get; set; }
        public string[] Vehicles { get; set; }
        public string[] Species { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string Url { get; set; }
    }
}
