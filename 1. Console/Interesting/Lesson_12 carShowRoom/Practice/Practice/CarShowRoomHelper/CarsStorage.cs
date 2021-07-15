using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.CarShowRoomHelper
{
    class CarsStorage
    {
        private static CarsStorage instance;
        public static CarsStorage Instance { get => instance ?? (instance = new CarsStorage()); }
        public List<Car> Cars { get; set; }

        private CarsStorage()
        {
            // по умолчанию будет 3 машины
            Cars = new List<Car>
            {
                new Car { Mark = "BMW", Model = "model_1", Price = 10_000, Color = "black", Country = "DE" },
                new Car { Mark = "Audi", Model = "model_2", Price = 20_000, Color = "red", Country = "DE" },
                new Car { Mark = "Lada", Model = "model_3", Price = 2_000, Color = "white", Country = "RU" }
            };
        }
    }
}
