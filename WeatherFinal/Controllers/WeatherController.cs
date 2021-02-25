using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherFinal.Models;
using WeatherFinal.ViewModels;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

namespace WeatherFinal.Controllers
{
    public class WeatherController : Controller
    {
        public async Task<IActionResult> Index(string? filter)
        {
            if (filter == null)
            {
                Weathervm weathervm = new Weathervm();
                return View(new Weathervm());
            }
            else
            {
                HttpClient client = new HttpClient();

                //MetaWeatherAPI
                string uri = "https://www.metaweather.com/api/location/search/?query=";


                //Add query filter to URI 
                if (filter != null)
                {
                    uri = uri + filter;
                }


                HttpResponseMessage response = await client.GetAsync(uri);
                string responseBody = await response.Content.ReadAsStringAsync();

                //Create new objects from json response
                var weather = JsonSerializer.Deserialize<List<Weather>>(responseBody);

                //Verify the response had any actual data
                if (weather.Count < 1)
                {
                    return Json(new Weathervm() { title = "No cities found. Please try another query" });
                }

                //Sort response alphabetically 
                weather.Sort();

                //Get current date
                string today = DateTime.Now.ToString("yyyy/MM/dd");

                //Get the cities weather for today
                uri = "https://www.metaweather.com/api/location/" + weather[0].woeid + "/" + today + "/";
                response = await client.GetAsync(uri);
                responseBody = await response.Content.ReadAsStringAsync();

               
                var temp = JsonSerializer.Deserialize<List<Temperature>>(responseBody);

                //Sort by temperatures. Assign maxtemp to the last temperature(the maximum temperature)
                temp.Sort();
                decimal maxtemp = temp[temp.Count - 1].the_temp;

                //Create viewmodel. Return as json
                Weathervm weathervm = new Weathervm() { title = weather[0].title, the_temp = maxtemp, weather_state_abbr = temp[temp.Count-1].weather_state_abbr };
                return Json(weathervm);
            }
        }

    }
}
