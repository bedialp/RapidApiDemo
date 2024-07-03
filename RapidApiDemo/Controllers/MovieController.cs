using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiDemo.Models;

namespace RapidApiDemo.Controllers
{
	public class MovieController : Controller
	{
		public async Task<IActionResult> MovieList()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
				Headers =
	{
		{ "x-rapidapi-key", "96c497f2f3msh6fb93be3d9128acp161261jsn608a27d73722" },
		{ "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<MovieViewModel>>(body);
				return View(values);
			}
		}
	}
}
