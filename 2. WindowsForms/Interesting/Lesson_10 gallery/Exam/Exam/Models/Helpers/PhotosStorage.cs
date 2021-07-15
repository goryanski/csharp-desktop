using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Helpers
{
    class PhotosStorage
    {
        private static PhotosStorage instance;
        public static PhotosStorage Instance { get => instance ?? (instance = new PhotosStorage()); }

        const string PATH = "photos.xml";
        public List<Photo> Photos { get; set; }

        private PhotosStorage() => Load();

        private void InitDefaultPhotos()
        {
            Photos = new List<Photo>
        {
                new Photo
                {
                    PhotoName = "Spring",
                    PhotoDescription = "В конце марта волна цветущей сакуры накрывает Японию. Начинают зацветать самые ранние сорта. А впереди буйство красок и природных красот, когда вся страна окутана бело-розовой пеной. С первых дней марта, когда начинает цвести слива, и до конца мая, когда в северных районах опадают лепестки сакуры, весеннее пробуждение природы радует и удивляет. Причем, не только самих японцев, но и миллионы туристов, приезжающих специально на сезон ханами.",
                    PhotoPath = Path.Combine(ImageSaveHelper.UPLOAD, "spring.jpg"),
                    DownloadDataTime = new DateTime(2020, 11, 18, 18, 30, 25),
                    PhotoCategory = "Nature",
                    PhotoAuthor = "admin"
                },
                new Photo
                {
                    PhotoName = "Summer",
                    PhotoDescription = "Пляж White Sand beach (Уайт Сэнд бич), или Virgin Beach (Вирджин бич) на Бали расположен недалеко от Чандидасы, между селами Бугбуг (Bugbug) и Пераси (Perasi). Это одно из немногих мест на востоке острова, где берег покрыт белым песком. Невысокие волны позволяют купаться и плавать с маской. Людей здесь мало, поскольку пляж удален от популярных туристических маршрутов.",
                    PhotoPath = Path.Combine(ImageSaveHelper.UPLOAD, "summer.jpg"),
                    DownloadDataTime = new DateTime(2020, 11, 18, 19, 40, 25),
                    PhotoCategory = "Nature",
                    PhotoAuthor = "admin"
                },
                new Photo
                {
                    PhotoName = "Autumn",
                    PhotoDescription = "Теплый денек, в конце октября, с солнечными лучиками, запутавшимися в рыжей листве и пряный, тягучий аромат, наполняющий осенний парк. Согласитесь, ведь надо совсем немного, чтобы почувствовать себя чуть-чуть счастливее",
                    PhotoPath = Path.Combine(ImageSaveHelper.UPLOAD, "Autumn.jpg"),
                    DownloadDataTime = new DateTime(2020, 11, 18, 23, 10, 24),
                    PhotoCategory = "Nature",
                    PhotoAuthor = "admin"
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
                    Photos = formatter.Deserialize(fs) as List<Photo>;                
                }
            }
            else
            {
                InitDefaultPhotos();
            }
        }

        public void SaveToFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (var fs = new FileStream(PATH, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, Photos);
            }
        }
    }
}
