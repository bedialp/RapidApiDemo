using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiDemo.Models;

namespace RapidApiDemo.Controllers
{
	public class WeatherController : Controller
	{
		public async Task<IActionResult> WeatherList()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://yahoo-weather5.p.rapidapi.com/weather?location=ankara&format=json&u=c"),
				Headers =
	{
		{ "x-rapidapi-key", "96c497f2f3msh6fb93be3d9128acp161261jsn608a27d73722" },
		{ "x-rapidapi-host", "yahoo-weather5.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<WeatherViewModel>(body);
				ViewBag.temp = result.current_observation.condition.temperature;
				ViewBag.sunset = result.current_observation.astronomy.sunset;
				ViewBag.sunrise = result.current_observation.astronomy.sunrise;
			}
			return View();
		}
	}
}
