using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Exam.Models;
using NLog;

namespace Exam.Storages
{
    class UsersStorage
    {
        private static UsersStorage instance;
        public static UsersStorage Instance { get => instance ?? (instance = new UsersStorage()); }

        BinaryFormatter formatter;
        PathsStorage pathsStorage;
        public List<UserInfo> Users { get; set; }

        private UsersStorage()
        { 
            Users = new List<UserInfo>();
            formatter = new BinaryFormatter();
            pathsStorage = PathsStorage.Instance;
            LoadData();
        }

        void LoadData()
        {
            if (File.Exists(pathsStorage.USERS_PATH))
            {
                Users.Clear();
                using (FileStream fs = new FileStream(pathsStorage.USERS_PATH, FileMode.Open, FileAccess.Read))
                {
                    Users = formatter.Deserialize(fs) as List<UserInfo>;
                }
            }
        }
        void SaveData()
        {
            using (FileStream fs = new FileStream(pathsStorage.USERS_PATH, FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(fs, Users);
            }
        }
        public void AddUser(UserInfo user)
        {
            Users.Add(user);
            SaveData();
        }

        internal void ChangeDate(int idx, DateTime birth)
        {
            Users[idx].Birth = birth;
            SaveData();
        }
    }
}