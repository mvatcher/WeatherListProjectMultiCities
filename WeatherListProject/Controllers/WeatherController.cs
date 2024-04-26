using Microsoft.AspNetCore.Mvc;

//using Newtonsoft.Json;
using System.Text.Json;

namespace WeatherProject.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {

        [HttpGet("[action]")] // /{city}
        public async Task<IActionResult> City(List<string> myCities)
        {
            using (var client = new HttpClient())

            {
                try
                {
                    var stringResult = "";
                    List<string> listReturns = new List<string>();
                    client.BaseAddress = new Uri("http://api.openweathermap.org");
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    foreach (string city in myCities)
                    {
                        Console.WriteLine(city);
                        var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid=ab2ac8f50aa62fc7ddfdce05ec5b1fac&units=imperial");
                        response.EnsureSuccessStatusCode();
                        stringResult = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(stringResult);
                        listReturns.Add(stringResult);

                    }
                                   
                    var rawWeatherA = JsonSerializer.Deserialize<OpenWeatherResponse>(listReturns[0], options);
                    var rawWeatherB = JsonSerializer.Deserialize<OpenWeatherResponse>(listReturns[1], options);
                    var rawWeatherC = JsonSerializer.Deserialize<OpenWeatherResponse>(listReturns[2], options);

                    return Ok(new
                    {

                        City = rawWeatherA.Name,
                        Temp = rawWeatherA.Main.Temp,
                        Summary = string.Join(",", rawWeatherA.Weather.Select(x => x.main)),
                        Wind = rawWeatherA.Wind.Speed,
                        CityB = rawWeatherB.Name,
                        TempB = rawWeatherB.Main.Temp,
                        SummaryB = string.Join(",", rawWeatherB.Weather.Select(x => x.main)),
                        WindB = rawWeatherB.Wind.Speed,
                        CityC = rawWeatherC.Name,
                        TempC = rawWeatherC.Main.Temp,
                        SummaryC = string.Join(",", rawWeatherC.Weather.Select(x => x.main)),                        
                        WindC = rawWeatherC.Wind.Speed

                    });
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
            }
        }

    }

}

