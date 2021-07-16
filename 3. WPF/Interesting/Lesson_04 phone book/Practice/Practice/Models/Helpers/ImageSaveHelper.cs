using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Models.Helpers
{
    class ImageSaveHelper
    {
        public const string UPLOAD = "photos";
        public static string Save(string fromPath)
        {
            if (!Directory.Exists(UPLOAD))
            {
                Directory.CreateDirectory(UPLOAD);
            }
            string filename = Path.GetFileName(fromPath);
            string guid = Guid.NewGuid().ToString();
            string toPath = Path.Combine(UPLOAD, $"{guid}_{filename}");
            File.Copy(fromPath, toPath);

            return toPath;
        }
    }
}
