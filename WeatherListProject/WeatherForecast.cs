namespace WeatherProject
{



    public class OpenWeatherResponse
    {
        //public Coord coord { get; set; }
        public Weather[] Weather { get; set; }
        //public string _base { get; set; }
        public Main Main { get; set; }
        //public int visibility { get; set; }
        public Wind Wind { get; set; }
        //public Clouds clouds { get; set; }
        //public int dt { get; set; }
        //public Sys sys { get; set; }
        //public int timezone { get; set; }
        //public int id { get; set; }
        public string Name { get; set; }
        //public int cod { get; set; }
    }

    //public class Coord
    //{
    //    public float lon { get; set; }
    //    public float lat { get; set; }
    //}

    public class Main
    {
        public float Temp { get; set; }
        //public float feels_like { get; set; }
        //public float temp_min { get; set; }
        //public float temp_max { get; set; }
        //public int pressure { get; set; }
        //public int humidity { get; set; }
    }

    public class Wind
    {
        public float Speed { get; set; }
        public float Deg { get; set; }
        public float Gust { get; set; }
    }

    //public class Clouds
    //{
    //    public int all { get; set; }
    //}

    //public class Sys
    //{
    //    public int type { get; set; }
    //    public int id { get; set; }
    //    public string country { get; set; }
    //    public int sunrise { get; set; }
    //    public int sunset { get; set; }
    //}

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}


