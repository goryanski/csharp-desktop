using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Helpers
{
    class UsersStorage
    {
        private static UsersStorage instance;
        public static UsersStorage Instance { get => instance ?? (instance = new UsersStorage()); }

        const string PATH = "users.xml";
        public List<User> Users { get; set; }

        private UsersStorage()
        {
            Users = new List<User>();
            LoadUsers();
        }

        private void LoadUsers()
        {
            if (File.Exists(PATH))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (var fs = new FileStream(PATH, FileMode.Open, FileAccess.Read))
                {
                    Users = formatter.Deserialize(fs) as List<User>;
                }
            }
        }

        public void SaveToFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (var fs = new FileStream(PATH, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, Users);
            }
        }

        internal bool UserExist(User user)
        {
            if(Users.Any(u => u.Login.Equals(user.Login)))
            {
                return true;
            }
            return false;
        }

        internal bool IsPasswordCorrect(User user)
        {
            // поскольку перед этим была проверка на существование юзера - можем смело пользоваться First без проверок
            var srchUser = Users.First(u => u.Login.Equals(user.Login));
            if (srchUser.Password.Equals(user.Password))
            {
                return true;
            }
            return false;
        }
    }
}
