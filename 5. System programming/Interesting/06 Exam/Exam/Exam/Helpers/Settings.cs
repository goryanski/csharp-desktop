using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Helpers
{
    public class Settings
    {
        public static string ForbiddenFIlesDirectory { get; set; }
        public static string EditedFIlesDirectory { get; set; }
        public static string ForbiddenWordReplacement { get; set; }
        public static string ReportFilePath{ get; set; }

        string forbiddenWordsFilePath;
        string contentForbiddenWordsFile;


        // Here you may set app settings
        public Settings()
        {
            ForbiddenFIlesDirectory = "ForbiddenWordsFIles";
            EditedFIlesDirectory = "EditedForbiddenWordsFIles";
            ReportFilePath = "ReportFile.txt";

            forbiddenWordsFilePath = "ForbiddenWordsList.txt";
            contentForbiddenWordsFile = "Romma, tddd, sex:    reno. Mero . Consectetur unde mistaken";

            ForbiddenWordReplacement = "*******";

            ApplySettings();          
        }

        private void ApplySettings()
        {
            // Create Forbidden Words File
            // if file already exists it is overwritten
            File.WriteAllText(forbiddenWordsFilePath, contentForbiddenWordsFile);

            // Create Directories
            if (!Directory.Exists(ForbiddenFIlesDirectory))
            {
                Directory.CreateDirectory(ForbiddenFIlesDirectory);
            }
            if (!Directory.Exists(EditedFIlesDirectory))
            {
                Directory.CreateDirectory(EditedFIlesDirectory);
            }           
        }
    }
}
