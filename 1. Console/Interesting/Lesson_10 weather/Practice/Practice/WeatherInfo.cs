using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class WeatherInfo
    {
        public DateTime Date { get; set; }
        public int MaximumTemperature { get; set; }
        public int MinimumTemperature { get; set; }
        public string WeatherSymbol { get; set; }
        public string TextWeatherSymbol { get; set; }
        public int WindStrength { get; set; }
        public string WindDirection { get; set; }
        public int SunDuration { get; set; }
        public int PrecipitationProbability { get; set; }

        public override string ToString()
        {
            return $"\nDate: {Date}\n" +
                $"Maximum temperature: {MaximumTemperature}\n" +
                $"Minimum temperature: {MinimumTemperature}\n" +
                $"Weather symbol: {WeatherSymbol}\n" +
                $"Text weather symbol: {TextWeatherSymbol}\n" +
                $"Wind strength: {WindStrength}\n" +
                $"Wind direction: {WindDirection}\n" +
                $"Sun duration: {SunDuration}\n" +
                $"Precipitation probability: {PrecipitationProbability}\n";
        }
    }
}
