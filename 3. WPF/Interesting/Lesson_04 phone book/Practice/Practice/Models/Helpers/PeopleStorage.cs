using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Practice.Models.Helpers
{
    class PeopleStorage
    {
        private static PeopleStorage instance;
        public static PeopleStorage Instance { get => instance ?? (instance = new PeopleStorage()); }

        const string PATH = "people.xml";
        public BindingList<Contact> People { get; set; }

        private PeopleStorage() => Load();

        private void InitDefaultPhotos()
        {
            People = new BindingList<Contact>
        {
                new Contact
                {
                     FirstName = "Vasiliy",
                     LastName = "Crews",
                     Photo = Path.GetFullPath(Path.Combine(ImageSaveHelper.UPLOAD, "man_1.jpg")),
                     PhoneNumber = "+380934094350",
                     Address = "Ukraine"
                },
                new Contact
                {
                    FirstName = "Masha",
                    LastName = "Nikitishna",
                    Photo = Path.GetFullPath(Path.Combine(ImageSaveHelper.UPLOAD, "woman_2.jpeg")),
                    PhoneNumber = "+380934094555",
                    Address = "Poland"
                },
                new Contact
                {
                    FirstName = "Ruslan",
                    LastName = "Sidorov",
                    Photo = Path.GetFullPath(Path.Combine(ImageSaveHelper.UPLOAD, "man_3.jpg")),
                    PhoneNumber = "+38097794451",
                    Address = "Germany"
                }
            };

            SaveToFile();
        }

        private void Load()
        {
            if (File.Exists(PATH))
            {
                var formatter = new XmlSerializer(typeof(BindingList<Contact>));

                using (var fs = new FileStream(PATH, FileMode.Open, FileAccess.Read))
                {
                    People = formatter.Deserialize(fs) as BindingList<Contact>;
                }
            }
            else
            {
                InitDefaultPhotos();
            }
        }

        public void SaveToFile()
        {
            var formatter = new XmlSerializer(typeof(BindingList<Contact>));

            using (var fs = new FileStream(PATH, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, People);
            }
        }
    }
}
