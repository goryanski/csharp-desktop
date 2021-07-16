using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UpdChatLibrary.Models;

namespace UpdChatLibrary.Helpers
{
    public class FileHelper
    {
        string path = Settings.ListOfMembersPath;

        public void CreateListOfMembersFile(List<Member> members)
        {
            if (!File.Exists(path))
            {         
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    formatter.Serialize(fs, members);
                }
            }
        }

        public void DeleteListOfMembersFile()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public List<Member> GetListOfMembersFile()
        {
            if (File.Exists(path))
            {
                List<Member> members = new List<Member>();
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    members = formatter.Deserialize(fs) as List<Member>;
                }
                return members;
            }
            return new List<Member>();
        }
    }
}
