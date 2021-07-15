using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Practice
{
    class Parse
    {
        public int CountFact { get; set; }
        public Country[] Parsing()
        {
            Country[] countries = new Country[300]; // больше быть не может
            int count = 0;
            CountFact = 0;

            WebClient wc = new WebClient();
            var bytes = wc.DownloadData("http://web.weeronline.nl/xml/examples/weeronline_travel_v2.xml");
            string xml = Encoding.UTF8.GetString(bytes);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement root = doc.DocumentElement;

            XmlNode world = root.ChildNodes[1];


            foreach (XmlNode node in world.ChildNodes)
            {
                if (node.Name.Equals("country"))
                {
                    Country country = new Country
                    {
                        CountryName = node.ChildNodes[0].InnerText,

                        Location = new Location
                        {
                            LocationName = node.ChildNodes[1].ChildNodes[0].InnerText,
                            Latitude = node.ChildNodes[1].ChildNodes[1].InnerText,
                            Longitude = node.ChildNodes[1].ChildNodes[2].InnerText,
                            Weather = FillWeather(node)
                        }
                    };
                    countries[count++] = country;

                    if(country != null)
                    {
                        CountFact++;
                    }
                }
            }

            return countries;
        }

        WeatherInfo[] FillWeather(XmlNode node)
        {
            int sizeArr = 6; // размер массива 6 потому что так нужно по структуре XML-документа
            int count = 0;
            WeatherInfo[] arr = new WeatherInfo[sizeArr];

            int start = 3; // начинается с 3 потому что так нужно по структуре XML-документа
            int end = start + sizeArr; // всего 6 проходов цикла

            for (int i = start; i < end; i++)
            {
                WeatherInfo weather = new WeatherInfo
                {
                    Date = DateTime.Parse(node.ChildNodes[1].ChildNodes[i].ChildNodes[0].InnerText),
                    MaximumTemperature = int.Parse(node.ChildNodes[1].ChildNodes[i].ChildNodes[1].InnerText),
                    MinimumTemperature = int.Parse(node.ChildNodes[1].ChildNodes[i].ChildNodes[2].InnerText),
                    WeatherSymbol = node.ChildNodes[1].ChildNodes[i].ChildNodes[3].InnerText,
                    TextWeatherSymbol = node.ChildNodes[1].ChildNodes[i].ChildNodes[4].InnerText,
                    WindStrength = int.Parse(node.ChildNodes[1].ChildNodes[i].ChildNodes[5].InnerText),
                    WindDirection = node.ChildNodes[1].ChildNodes[i].ChildNodes[6].InnerText,
                    SunDuration = int.Parse(node.ChildNodes[1].ChildNodes[i].ChildNodes[7].InnerText),
                    PrecipitationProbability = int.Parse(node.ChildNodes[1].ChildNodes[i].ChildNodes[8].InnerText)
                };

                arr[count++] = weather;
            }

            return arr;
        }
    }
}
