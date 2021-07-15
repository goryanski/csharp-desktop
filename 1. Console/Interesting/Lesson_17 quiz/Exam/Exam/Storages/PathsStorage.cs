using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Storages
{
    class PathsStorage
    {
        private static PathsStorage instance;
        public static PathsStorage Instance { get => instance ?? (instance = new PathsStorage()); }

        public string USERS_PATH = "users.bin";
        public string ACCOUNTS_PATH = "accounts.bin";
        public string ADMIN_PATH = @"TestManagementUtility\AdminData.txt";
        public string TESTS_PATH = @"TestManagementUtility\tests.bin";
        public string ANSWERS_PATH = @"TestManagementUtility\answers.bin";
        public string RESULTS_PATH = @"TestManagementUtility\results.bin";

        private PathsStorage() { }        
    }
}
