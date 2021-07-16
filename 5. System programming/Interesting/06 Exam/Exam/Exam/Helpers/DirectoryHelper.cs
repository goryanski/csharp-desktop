using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Helpers
{
    public class DirectoryHelper
    {
        public void ClearDirectory(string path)
        {
            string[] allFiles = Directory.GetFiles(path);
            if (allFiles.Length > 0)
            {
                foreach (var file in allFiles)
                {
                    File.Delete(file);
                }
            }
        }
    }
}
