using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherFinal.Models
{
    public class Temperature : IComparable
    {
        public long id { get; set; }
        public string weather_state_name { get; set; }
        public string weather_state_abbr { get; set; }
        public string wind_direction_compass { get; set; }
        public DateTime created { get; set; }
        public string applicable_date { get; set; }
        public decimal min_temp { get; set; }
        public decimal max_temp { get; set; }
        public decimal the_temp { get; set; }
        public decimal wind_speed { get; set; }
        public decimal wind_direction { get; set; }
        public decimal air_pressure { get; set; }
        public int humidity { get; set; }

        public decimal? visibility { get; set; }
        public int predictability { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Temperature othertemp = obj as Temperature;
            if (this.the_temp > othertemp.the_temp)
            {
                return 1;
            }
            else if (this.the_temp < othertemp.the_temp)
            {
                return -1;
            }
            else
            {
                return 0;

            }
        }
    }
}
