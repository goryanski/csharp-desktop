using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Application
    {
        public void Start()
        {
            Parse parse = new Parse();
            Country[] countries = parse.Parsing();

            ShowCountriesNames(countries, parse);

            Console.Write("Enter the number of the country where you want to see the weather: ");
            int select;
            int.TryParse(Console.ReadLine(), out select);

            while (select < 1 || select > countries.Length)
            {
                Console.Write("Wrong number, try again: ");
                int.TryParse(Console.ReadLine(), out select);
            }

            ShowWeather(select - 1, countries);
        }

        void ShowCountriesNames(Country[] countries, Parse parse)
        {
            int count = 1;
            for (int i = 0; i < parse.CountFact; i++)
            {
                Console.Write($"[{count++}] ");
                Console.WriteLine(countries[i].CountryName);
            }
            Console.WriteLine();
        }

        private void ShowWeather(int select, Country[] countries)
        {
            Console.Clear();
            string country = countries[select].CountryName;
            string city = countries[select].Location.LocationName;

            Console.WriteLine($"Weather in {country}, {city}:");
            var arr = countries[select].Location.Weather;

            foreach (var weather in arr)
            {
                Console.WriteLine(weather);
                Console.WriteLine();
            }
        }
    }
}
