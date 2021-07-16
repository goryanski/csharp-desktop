using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exam.Helpers;
using Exam.Models;
using System.Diagnostics; // for OpenReportFIle

namespace Exam
{
    public partial class Form1 : Form
    {
        enum StateOfWork
        {
            None,
            WorkStoped,
            WorkSuspended,
            ResumeWork,
            RestartWork
        }

        StateOfWork stateOfWork = StateOfWork.None;

        RecursiveFilesSearcher fileSearcher = new RecursiveFilesSearcher();
        FileHelper fileHelper = new FileHelper();
        DirectoryHelper directoryHelper = new DirectoryHelper();

        string[] keyWords;
        // each List has its own file state, a different number of files, needed for different ListBox 
        List<SelectedFile> allFiles = new List<SelectedFile>();
        List<SelectedFile> forbiddenFiles = new List<SelectedFile>();
        List<SelectedFile> editedFiles = new List<SelectedFile>();


        public Form1()
        {
            InitializeComponent();          
            this.StartPosition = FormStartPosition.CenterScreen;
            Load += Form_Load;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            new Settings();
            HideControls();
            StartupPreparations();
   
            // Subscribe to events of ending tasks
            Subscriptions();
        }

        private void HideControls()
        {
            btnGetStarted.Visible = false;
            btnPause.Visible = false;
            btnStop.Visible = false;
            btnRestart.Visible = false;
            btnResume.Visible = false;
            lblPleaseWait.Visible = false;
        }
        private void StartupPreparations(bool extended = false)
        {
            if (extended) // for restart
            {
                btnStop.Enabled = true;
                btnRestart.Enabled = false;
                btnPause.Enabled = true;

                fileHelper.FilesToEdit.Clear();
                fileHelper.ForbiddenFiles.Clear();
                fileHelper.UniqueNameId = 0;
                fileSearcher.AllFiles.Clear();

                allFiles.Clear();
                forbiddenFiles.Clear();
                editedFiles.Clear();

                UpdateLbSrchFiles(true);
                UpdateLbForbiddenWordsFiles(true);
                UpdateLbEditedFilesInfo(true);
                lblCountAllFiles.Text = string.Empty;
                lblForbiddenWordsFilesCount.Text = string.Empty;

                fileSearcher.AppStoped = false;
                fileHelper.AppStoped = false;
                lblPleaseWait.Visible = true;
                progressBar.Value = 0;

                stateOfWork = StateOfWork.RestartWork;
            }

            lblPleaseWait.Text = "Working...";
            btnOpenReportFIle.Visible = false;

            // Delete all forbidden Files every time
            directoryHelper.ClearDirectory(Settings.ForbiddenFIlesDirectory);

            // Delete all edited forbidden Files every time
            directoryHelper.ClearDirectory(Settings.EditedFIlesDirectory);

            // Delete report
            if (File.Exists(Settings.ReportFilePath))
            {
                File.Delete(Settings.ReportFilePath);
            }          
        }

       

        private void Subscriptions()
        {
            #region Ending of main tasks

            // Subscribe to events of Ending recursive Files Search
            fileSearcher.EndingFilesSearch += () =>
            {
                // fill ListBox lbSrchFiles
                allFiles = fileSearcher.AllFiles;
                UpdateLbSrchFiles();
                
                BeginInvoke(new Action(() =>
                {                   
                    lblCountAllFiles.Text = allFiles.Count.ToString();
                }));

                // if user pressed stop
                if (stateOfWork == StateOfWork.WorkStoped)
                {
                    ShowWorkStoped();
                    return;
                }

                // now we can find Forbidden FIles use List of allFiles 
                fileHelper.FindForbiddenFIles(allFiles, keyWords);
                // when the search is over - see the next event (below)
            };

            // Subscribe to events of Ending forbidden Files Search
            fileHelper.EndingForbiddenFilesSearch += () =>
            {             
                forbiddenFiles = fileHelper.ForbiddenFiles;
                editedFiles = fileHelper.FilesToEdit;

                // fill ListBox lbForbiddenWordsFiles
                UpdateLbForbiddenWordsFiles();
                BeginInvoke(new Action(() =>
                {
                    lblForbiddenWordsFilesCount.Text = forbiddenFiles.Count.ToString();                
                }));

                if (stateOfWork == StateOfWork.WorkStoped)
                {
                    ShowWorkStoped();
                    return;
                }

                BeginInvoke(new Action(() =>
                {
                    // Forbidden Files Search - 40% of all application work
                    progressBar.Value = 70;
                }));

                fileHelper.EditForbiddenFIles(keyWords);
            };
            

            // Subscribe to events of Ending forbidden Files Edit
            fileHelper.EndingForbiddenFilesEdit += () =>
            {
                // file state change so update editedFiles list
                editedFiles = fileHelper.FilesToEdit;
                UpdateLbEditedFilesInfo();

                if (stateOfWork == StateOfWork.WorkStoped)
                {
                    ShowWorkStoped();
                    return;
                }

                // finish  
                fileHelper.CreateReportFile();

                BeginInvoke(new Action(() =>
                {
                    progressBar.Value = 100;
                    btnStop.Enabled = false;
                    btnPause.Enabled = false;
                    lblPleaseWait.Text = "Finish";
                    btnRestart.Visible = true;
                    btnRestart.Enabled = true;
                }));
            };
            #endregion

            #region For smooth change of progress bar
            fileSearcher.IncreaseProgressBarValue += (progress) =>
            {
                BeginInvoke(new Action(() =>
                {
                    progressBar.Value += progress;                   
                }));                              
            };
            fileHelper.IncreaseProgressBarValue += (progress) =>
            {
                BeginInvoke(new Action(() =>
                {
                    progressBar.Value += progress;
                }));
            };
            #endregion

            #region Stop and Pause while working of main tasks
            // stop
            fileSearcher.CheckIfAppStoped += () =>
            {
                if (stateOfWork == StateOfWork.WorkStoped)
                {
                    fileSearcher.AppStoped = true;
                }
            };
            fileHelper.CheckIfAppStoped += () =>
            {
                if (stateOfWork == StateOfWork.WorkStoped)
                {
                    fileHelper.AppStoped = true;
                }
            };

            // pause
            fileSearcher.CheckIfAppSuspended += () =>
            {
                GetPause();               
            };
            fileHelper.CheckIfAppSuspended += () =>
            {
                GetPause();
            };
            #endregion

            fileHelper.EndingReportFileCreate += () =>
            {
                BeginInvoke(new Action(() =>
                {
                    btnOpenReportFIle.Visible = true;
                }));
            };
        }   


        #region Forbidden words selection
        private void BtnConfirmWordsList_Click(object sender, EventArgs e)
        {
            if (tbForbiddenWordsList.Text != string.Empty)
            {
                string[] splittedWords = fileHelper.SplitText(tbForbiddenWordsList.Text);
                MemorizeKeyWords(splittedWords);
                ShowSplittedText(splittedWords);
                FinishWordsSelection();
            }
        }

        private void BtnUploadFromFile_Click(object sender, EventArgs e)
        {
            if (File.Exists("ForbiddenWordsList.txt"))
            {
                string content = File.ReadAllText("ForbiddenWordsList.txt");
                string[] splittedWords = fileHelper.SplitText(content);
                MemorizeKeyWords(splittedWords);
                ShowSplittedText(splittedWords);
                FinishWordsSelection();
            }
            else
            {
                MessageBox.Show("File not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void MemorizeKeyWords(string[] splittedWords) => keyWords = splittedWords;

        void ShowSplittedText(string[] splittedText)
        {
            foreach (var word in splittedText)
            {
                lblForbiddenWordsList.Text += $"\n {word}";
            }
        }

        void FinishWordsSelection()
        {
            tbForbiddenWordsList.Enabled = false;
            btnConfirmWordsList.Enabled = false;
            btnUploadFromFile.Enabled = false;
            btnGetStarted.Visible = true;
        }
        #endregion

        private void BtnGetStarted_Click(object sender, EventArgs e)
        {            
            fileSearcher.Start();
            lblPleaseWait.Visible = true;
            btnStop.Visible = true;
            btnPause.Visible = true;
            btnGetStarted.Enabled = false;
        }

        #region Stop, Pause, Resume, Restart

        #region Buttons Click
        private void BtnStop_Click(object sender, EventArgs e)
        {
            stateOfWork = StateOfWork.WorkStoped;
            lblPleaseWait.Text = "Application is stopping, please wait";
            btnPause.Enabled = false;
            btnStop.Enabled = false;
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            stateOfWork = StateOfWork.WorkSuspended;
            lblPleaseWait.Text = "Application is suspending, please wait";
            btnPause.Enabled = false;
            btnStop.Enabled = false;
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            StartupPreparations(true);           
            fileSearcher.Start();
        }

        private void BtnResume_Click(object sender, EventArgs e)
        {
            stateOfWork = StateOfWork.ResumeWork;
        }
        #endregion

        private void GetPause()
        {
            if (stateOfWork == StateOfWork.WorkSuspended)
            {
                BeginInvoke(new Action(() =>
                {
                    btnResume.Enabled = true;
                    btnResume.Visible = true;
                    btnRestart.Enabled = false;
                    lblPleaseWait.Text = "Application suspended";
                }));

                // just wait for the user to click the "Resume" button
                while (stateOfWork != StateOfWork.ResumeWork) { }

                BeginInvoke(new Action(() =>
                {
                    lblPleaseWait.Text = "Working...";
                    btnResume.Enabled = false;
                    btnPause.Enabled = true;
                    btnStop.Enabled = true;
                }));
            }
        }

        private void ShowWorkStoped()
        {
            BeginInvoke(new Action(() =>
            {
                btnRestart.Visible = true;
                btnRestart.Enabled = true;
                lblPleaseWait.Text = "Work stoped";
            }));
        }

        #endregion

        #region ListBox update
        private void UpdateLbSrchFiles(bool isRestart = false)
        {
            if (isRestart)
            {
                ListBoxUpdate(lbSrchFiles, allFiles);
            }
            else
            {
                BeginInvoke(new Action(() =>
                {
                    ListBoxUpdate(lbSrchFiles, allFiles);
                }));
            }         
        }

        private void UpdateLbForbiddenWordsFiles(bool isRestart = false)
        {
            if (isRestart)
            {
                ListBoxUpdate(lbForbiddenWordsFiles, forbiddenFiles);
            }
            else
            {
                BeginInvoke(new Action(() =>
                {
                    ListBoxUpdate(lbForbiddenWordsFiles, forbiddenFiles);
                }));
            }
        }

        private void UpdateLbEditedFilesInfo(bool isRestart = false)
        {
            if (isRestart)
            {
                ListBoxUpdate(lbEditedFilesInfo, editedFiles);
            }
            else
            {
                BeginInvoke(new Action(() =>
                {
                    ListBoxUpdate(lbEditedFilesInfo, editedFiles);
                }));
            }
        }

        void ListBoxUpdate(ListBox listBox, List<SelectedFile> filesList)
        {
            listBox.DataSource = null;
            listBox.DataSource = filesList;

        }
        #endregion

        private void BtnOpenReportFIle_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.ReportFilePath);
        }
    }
}