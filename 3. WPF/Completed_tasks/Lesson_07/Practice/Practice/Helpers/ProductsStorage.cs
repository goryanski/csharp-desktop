using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Practice.Controls;

namespace Practice.Helpers
{
    class ProductsStorage
    {
        private static ProductsStorage instance;
        public static ProductsStorage Instance { get => instance ?? (instance = new ProductsStorage()); }

        const string PATH = "products.xml";
        public BindingList<Product> Products { get; set; }

        private ProductsStorage() => Load();

        private void InitDefaultProducts()
        {
            Products = new BindingList<Product>
        {
                new Product
                {
                     Title="Table tennis racket DHS 5002C",
                     Price = 500,
                     Description="The DHS 5002C tennis racket is versatile and suitable for various playing styles. With its 5-ply All-round blade and quality Hurricane 3 and Skyline 3 stretch overlays, it will perform well for defense, but will also appeal to advanced tennis players with an aggressive playstyle.",
                     Seller="Valera",
                     Category="Sport",
                     CreatedDate = new DateTime(2020, 12, 05, 19, 40, 25),
                     Picture = Path.GetFullPath(Path.Combine(ImageSaveHelper.UPLOAD, "racquet_1.jpg")),
                     Rating = 8                   
                },
                new Product
                {
                     Title="relooo racket RR 123",
                     Price = 200,
                     Description="For players with an intermediate level of play and confident amateurs. It has good speed and a fairly sticky surface, which significantly improves ball bounce and allows you to resort to spin during the game. Thanks to the semi-professional rubbers in its arsenal, the DHS 3002 has become a bestseller among beginners and amateurs in many countries around the world, especially in China. After all, it is the Chinese team that currently uses Double Happines rackets when participating in tournaments.",
                     Seller="Ignat",
                     Category="Sport",
                     CreatedDate = new DateTime(2020, 12, 05, 19, 20, 27),
                     Picture = Path.GetFullPath(Path.Combine(ImageSaveHelper.UPLOAD, "racquet_2.jpg")),
                     Rating = 7
                },
                new Product
                {
                    Title="Werona tennis racket YY16 re",
                     Price = 1000,
                     Description="Suitable for experienced amateurs and professional table tennis players. The model is equipped with two popular Harricane 3 rubbers - for powerful topspins and strong spins and the G888 with excellent spin and good control. A quality wooden base with a FL handle fits comfortably in the hand and allows you to unleash the full potential of the pads used.",
                     Seller="Tamara",
                     Category="Sport",
                     Rating = 10,
                     CreatedDate = new DateTime(2020, 12, 05, 13, 42, 11),
                     Picture = Path.GetFullPath(Path.Combine(ImageSaveHelper.UPLOAD, "racquet_3.jpg")),
                }
            };

            SaveToFile();
        }

        private void Load()
        {
            if (File.Exists(PATH))
            {
                BindingList<SavedProduct> tmpList = new BindingList<SavedProduct>();
                var formatter = new XmlSerializer(typeof(BindingList<SavedProduct>));
                

                using (var fs = new FileStream(PATH, FileMode.Open, FileAccess.Read))
                {
                    tmpList = formatter.Deserialize(fs) as BindingList<SavedProduct>;
                }


                // скопируем обратно продукты при загрузке
                Products = new BindingList<Product>();
                for (int i = 0; i < tmpList.Count; i++)
                {
                    Product product = new Product();
                    product.Copy(tmpList[i]);
                    Products.Add(product);
                }
            }
            else
            {
                InitDefaultProducts();
            }
        }

        public void SaveToFile()
        {
            // поскольку класс Product нельзя серилизовать, скопируем из списка классов Product все данные в список классов, которые сериализуются
            BindingList<SavedProduct> tmpList = new BindingList<SavedProduct>();
            for (int i = 0; i < Products.Count; i++)
            {
                SavedProduct savedProduct = new SavedProduct();
                savedProduct.Copy(Products[i]);                
                tmpList.Add(savedProduct);
            }
            

            var formatter = new XmlSerializer(typeof(BindingList<SavedProduct>));

            using (var fs = new FileStream(PATH, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, tmpList);
            }
        }
    }
}
