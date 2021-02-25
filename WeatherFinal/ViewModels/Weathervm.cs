using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WeatherFinal.ViewModels
{
    public class Weathervm
    {
        [Display(Name = "City", Prompt = "Enter City Name")]
        public string? title { get; set; }
        [Display(Name ="Max Temp")]
        public decimal the_temp { get; set; }
        public string weather_state_abbr { get; set; }
    }
}
