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
    class AccountsStorage
    {
        private static AccountsStorage instance;
        public static AccountsStorage Instance { get => instance ?? (instance = new AccountsStorage()); }
        public List<Account> Accounts { get; set; }
        readonly Logger logger;
        BinaryFormatter formatter;
        PathsStorage pathsStorage;

        private AccountsStorage()
        {
            Accounts = new List<Account>();
            logger = LogManager.GetCurrentClassLogger();
            formatter = new BinaryFormatter();
            pathsStorage = PathsStorage.Instance;
            LoadData();
        }

        void LoadData()
        {
            if (File.Exists(pathsStorage.ACCOUNTS_PATH))
            {
                Accounts.Clear();
                using (FileStream fs = new FileStream(pathsStorage.ACCOUNTS_PATH, FileMode.Open, FileAccess.Read))
                {
                    Accounts = formatter.Deserialize(fs) as List<Account>;
                }
            }
        }
        void SaveData()
        {
            using (FileStream fs = new FileStream(pathsStorage.ACCOUNTS_PATH, FileMode.OpenOrCreate, FileAccess.Write))
            {
                formatter.Serialize(fs, Accounts);
            }
        }
        public bool AddAccount(Account account)
        {
            // попробуем найти аккаунт с таким же логином, если нашли - то добавлять не будем и вернем результат работы метода как false
            try
            {
                Accounts.First(u => u.Login.Equals(account.Login));
                logger.Warn("User already exist");
                return false;
            }
            catch (InvalidOperationException)
            {
                Accounts.Add(account);
                SaveData(); // и сразу же запишем в файл обновленную информацию
                return true;
            }
        }

        internal void ChangePassword(int idx, string password)
        {
            Accounts[idx].Password = password;
            SaveData();
        }
    }
}
  