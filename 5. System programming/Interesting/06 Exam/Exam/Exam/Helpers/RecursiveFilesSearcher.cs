using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Exam.Models;

namespace Exam.Helpers
{
    public class RecursiveFilesSearcher
    {
        public List<SelectedFile> AllFiles { get; set; } = new List<SelectedFile>();
        public event Action EndingFilesSearch;
        public event Action<int> IncreaseProgressBarValue;
        public event Action CheckIfAppStoped;
        public event Action CheckIfAppSuspended;

        public bool AppStoped { get; set; } = false;

        public async void Start()
        {
            await Task.Run(() => 
            {
                // start with 2% in Progress Bar
                IncreaseProgressBarValue?.Invoke(2);

                string[] drives = Environment.GetLogicalDrives();

                int drivesCount = drives.Length;
                // this method (Start) - 30% of all application work
                int progressStep = 30 / drivesCount;

                foreach (string dr in drives)
                {
                    DriveInfo di = new DriveInfo(dr);

                    // Here we skip the drive if it is not ready to be read
                    if (!di.IsReady)
                    {
                        continue;
                    }

                    DirectoryInfo rootDir = di.RootDirectory;
                    WalkDirectoryTree(rootDir);

                    IncreaseProgressBarValue?.Invoke(progressStep);
                    CheckIfAppStoped?.Invoke();
                    if (AppStoped) break;

                    CheckIfAppSuspended?.Invoke();
                }

                // When all files are found, we notify about it to get the result in Form1.cs
                EndingFilesSearch?.Invoke();
            });        
        }

        void WalkDirectoryTree(DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder
            try
            {
                files = root.GetFiles("*.txt");
            }
            // This is thrown if even one of the files requires permissions greater than the application provides. just skip these files
            catch (UnauthorizedAccessException) { }
            catch (DirectoryNotFoundException) { }

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    
                    // add info of every file to result list
                    SelectedFile selectedFile = new SelectedFile
                    {
                        Name = fi.Name,
                        FullPath = fi.FullName,
                        State = State.Found,
                        Size = fi.Length
                    };
                    AllFiles.Add(selectedFile);
                }


                // Now find all the subdirectories under this directory
                subDirs = root.GetDirectories();

                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    // Resursive call for each subdirectory
                    WalkDirectoryTree(dirInfo);
                }
            }
        }
    }
}
