using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherViewer.Models
{
    public class TemperatureWindModel
    {
        public int temperature { get; set; }
        public string temperatureUnit { get; set; }
        public string windSpeed { get; set; }
        public string windDirection { get; set; }
    }
}
