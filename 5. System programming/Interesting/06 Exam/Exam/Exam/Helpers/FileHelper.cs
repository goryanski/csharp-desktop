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
    public class FileHelper
    {
        public List<SelectedFile> ForbiddenFiles { get; set; } = new List<SelectedFile>();
        public List<SelectedFile> FilesToEdit { get; set; } = new List<SelectedFile>();
        public event Action EndingForbiddenFilesSearch;
        public event Action EndingForbiddenFilesEdit;
        public event Action EndingReportFileCreate;
        public event Action<int> IncreaseProgressBarValue;

        public event Action CheckIfAppStoped;
        public event Action CheckIfAppSuspended;
        public bool AppStoped { get; set; } = false;
        public int UniqueNameId { get; set; } = 0;

        public List<ForbiddenWord> ForbiddenWordsInfo { get; set; } = new List<ForbiddenWord>();
       

        public async void FindForbiddenFIles(List<SelectedFile> allFiles, string[] keyWords)
        {
            await Task.Run(() => 
            {
                int ProgressCounter = 0;
                foreach (var file in allFiles)
                {                   
                    try
                    {
                        string content = File.ReadAllText(file.FullPath);

                        // all text in the file must be split to compare accurately
                        string[] splittedContent = SplitText(content);

                        foreach (var word in splittedContent)
                        {
                            bool isFileFound = false;
                            foreach (var forbiddenWord in keyWords)
                            {
                                if (word.ToLower().Equals(forbiddenWord.ToLower()))
                                {
                                    // copy file in specified folder with forbidden fIles
                                    File.Copy(file.FullPath, Path.Combine(Settings.ForbiddenFIlesDirectory, GetUniqueFileName(file.Name)));
                                    ForbiddenFiles.Add(file);

                                    // copy file in specified folder with edited forbidden fIles
                                    string newFullPath = Path.Combine(Settings.EditedFIlesDirectory, GetUniqueFileName(file.Name));
                                    File.Copy(file.FullPath, newFullPath);

                                    SelectedFile fileToEdit = new SelectedFile
                                    {
                                        Name = file.Name,
                                        FullPath = newFullPath,
                                        Size = file.Size
                                    };
                                    FilesToEdit.Add(fileToEdit);


                                    // for smooth change of progress bar
                                    if (ProgressCounter < 30)
                                    {
                                        IncreaseProgressBarValue?.Invoke(1);
                                        ProgressCounter++;
                                    }                                   

                                    isFileFound = true;
                                    break;
                                }
                            }
                            if (isFileFound) break;
                        }
                    }
                    // just skip  
                    catch (DirectoryNotFoundException) { }                  
                    catch (UnauthorizedAccessException) { }

                    CheckIfAppStoped?.Invoke();
                    if (AppStoped) break;

                    CheckIfAppSuspended?.Invoke();
                }

                // When all forbidden files are found, we notify about it to get the result in Form1.cs
                EndingForbiddenFilesSearch?.Invoke();
            });
        }

        public async void EditForbiddenFIles(string[] keyWords)
        {
            await Task.Run(() =>
            {

                // for report file
                ForbiddenWordsInfo.Clear();
                foreach (var word in keyWords)
                {
                    ForbiddenWordsInfo.Add(new ForbiddenWord { Word = word });
                }

                int ProgressCounter = 0;
                foreach (var file in FilesToEdit)
                {
                    int forbiddenWordsCount = 0;

                    string content = File.ReadAllText(file.FullPath);
                    string[] splittedContent = SplitText(content);

                    foreach (var word in splittedContent)
                    {
                        foreach (var forbiddenWord in keyWords)
                        {
                            if (word.ToLower().Equals(forbiddenWord.ToLower()))
                            {
                                // for report file
                                ForbiddenWordsInfo.First(w => w.Word.Equals(forbiddenWord)).Count++;    
                                content = content.Replace(word, Settings.ForbiddenWordReplacement);
                                File.WriteAllText(file.FullPath, content);
                                file.State = State.Edited;
                                file.ForbiddenWordsCount = ++forbiddenWordsCount;

                                // for smooth change of progress bar
                                if (ProgressCounter < 25)
                                {
                                    IncreaseProgressBarValue?.Invoke(1);
                                    ProgressCounter++;
                                }
                            }
                        }
                    }
                    CheckIfAppStoped?.Invoke();
                    if (AppStoped) break;

                    CheckIfAppSuspended?.Invoke();
                }
                EndingForbiddenFilesEdit?.Invoke();             
            });
        }

        public async void CreateReportFile()
        {
            await Task.Run(() =>
            {
                int counter = 0;
                string report = string.Empty;
                foreach (var file in FilesToEdit)
                {                  
                    report += $"{++counter}. File name: {file.Name}, State: {file.State}, File size: {file.Size}, File Path: {file.FullPath}, Count of forbidden words: {file.ForbiddenWordsCount}\n";
                }

                
                var popularForbiddenWords = ForbiddenWordsInfo
                    .OrderByDescending(w => w.Count)
                    .Take(10)
                    .Where(w => w.Count > 0)
                    .ToList();
                

                report += $"\n\n\nTop most popular forbidden words:\n";
                if(popularForbiddenWords.Count > 0)
                {
                    int forbiddenWordsCounter = 0;
                    foreach (var word in popularForbiddenWords)
                    {
                        report += $"{++forbiddenWordsCounter}. {word}\n";
                    }
                }
                else
                {
                    report += $"There're no popular forbidden words";
                }
               
                File.WriteAllText(Settings.ReportFilePath, report);
                EndingReportFileCreate?.Invoke();
            });
        }

        public string[] SplitText(string text)
        {
            return text.Split(new Char[] { ' ', ',', '.', ':', '!', '?', ';', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        string GetUniqueFileName(string name) => $"{++UniqueNameId}{name}";    
    }
}
