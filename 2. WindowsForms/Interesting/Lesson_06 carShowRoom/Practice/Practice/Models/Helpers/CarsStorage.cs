using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Practice.Models;
using Practice.Models.Helpers;

namespace Practice
{
    class CarsStorage
    {
        private static CarsStorage instance;
        public static CarsStorage Instance { get => instance ?? (instance = new CarsStorage()); }

        const string PATH = "cars.xml";
        public List<Car> Cars { get; set; }

        private CarsStorage() => Load();

        private void InitDefaultCars()
        {
            Cars = new List<Car>
            {
                new Car
                {
                    Mark = "BMW",
                    Model = "X5",
                    Price = 50_000,
                    Color = "black",
                    Country = "DE",
                    PicturePath = Path.Combine(ImageSaveHelper.UPLOAD, "bmw_x5.jpg")
                },
                new Car
                {
                    Mark = "Audi",
                    Model = "R8",
                    Price = 100_000,
                    Color = "black",
                    Country = "DE",
                    PicturePath = Path.Combine(ImageSaveHelper.UPLOAD, "audi_r8.jpg")
                },
                new Car
                {
                    Mark = "Lada",
                    Model = "Sedan",
                    Price = 1_000,
                    Color = "baklajan",
                    Country = "RU",
                    PicturePath = Path.Combine(ImageSaveHelper.UPLOAD, "lada_sedan.jpg")
                }
            };

            SaveToFile();
        }

        private void Load()
        {
            if (File.Exists(PATH))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (var fs = new FileStream(PATH, FileMode.Open, FileAccess.Read))
                {
                    Cars = formatter.Deserialize(fs) as List<Car>;
                }
            }
            else
            {
                InitDefaultCars();
            }
        }

        public void SaveToFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (var fs = new FileStream(PATH, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, Cars);
            }
        }
    }
}
