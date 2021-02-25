using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherFinal.Models
{
    public class Weather : IComparable
    {
        public string title { get; set; }
        public string location_type { get; set; }
        public int woeid { get; set; }
        public string latt_long { get; set; }

        public int CompareTo(object obj)
        {
            Weather otherWeather = obj as Weather;
            if (otherWeather == null)
            {
                return 1;
            }
            else
            {
                return this.title.CompareTo(otherWeather.title);
            }
        }
    }
}
