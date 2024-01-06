using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text.Json.Nodes;

namespace WeatherAPITests{

    public class WeatherObject{
        public double latitude {set; get;}
        public double longitude {set; get;}

        public float generationtime_ms {set; get;}
        public int utc_offset_seconds {get; set;}

        public string timezone {set; get;}

        public string timezone_abbreviation {set; get;}
        public double elevation {get; set;}
        public Dictionary<string, string> hourly_units {set; get;}
        public Dictionary<string, ArrayList> hourly {set; get;}

    }
}
