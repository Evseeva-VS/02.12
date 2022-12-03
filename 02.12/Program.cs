using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _02._12
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // чтение данных
            using (FileStream fs = new FileStream("response.json", FileMode.OpenOrCreate))
            {
                Weather weather = await JsonSerializer.DeserializeAsync<Weather>(fs);
                Console.WriteLine($"Name: {weather?.season} Age: {weather?.temp}");
            }
        }
    }

    // Класс данных
    public class Weather
    {
        public DateTime now { get; set; }
        public Info info { get; set; }
        public int temp { get; set; }
        public int feels_like { get; set; }
        public string condition { get; set; }
        public string season { get; set; }
    }
    public class Info
    {
        public float lat { get; set; }
        public float lon { get; set; }
        public TZInfo tzinfo { get; set; }

    }
    public class TZInfo
    {
        public string name { get; set; }
        public string abbr { get; set; }
        public bool dst { get; set; }
    }
}
