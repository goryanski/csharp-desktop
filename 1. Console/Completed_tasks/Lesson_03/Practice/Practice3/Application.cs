using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3
{
    class Application
    {
        public Storage[] AllMemory { get; set; }

        public void Start()
        {
            CreateStorages();

            while (true)
            {
                Console.WriteLine("\n[1] Сalculate all memory volume");
                Console.WriteLine("[2] Copy info to device");
                Console.WriteLine("[3] Сalculate time to copy");
                Console.WriteLine("[4] Сalculate storages quantity");
                Console.WriteLine("[5] Exit");

                int action;
                int.TryParse(Console.ReadLine(), out action);


                switch (action)
                {
                    case 1:
                        {                         
                            double AllVolume = 0.0;
                            foreach (var item in AllMemory)
                            {
                                AllVolume += item.GetMemoryVolume();
                            }

                            Console.WriteLine($"All memory volume: {AllVolume}");

                            break;
                        }
                    case 2:
                        Console.WriteLine("Copy info to device ...");
                        break;
                    case 3:
                        Console.WriteLine("Сalculate time to copy ...");
                        break;
                    case 4:
                        Console.WriteLine("Сalculate storages quantity ...");
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public void CreateStorages()
        {
            AllMemory = new Storage[]
            {
                new Flash
                {
                    StorageName = "flesh",
                    Model = "qwe12",
                    MemoryVolume = 32,
                    Speed = 100
                },
                new DVD
                {
                    StorageName = "Driver",
                    Model = "CD-RW",
                    Type = 1,
                    Speed = 200
                },
                new HDD
                {
                    StorageName = "hdd",
                    Model = "rew22",
                    MemoryVolume = 500,
                    PartitionQuantity = 3,
                    Speed = 400
                }
            };
        }

    }
}

