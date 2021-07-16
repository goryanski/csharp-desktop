
namespace Exam
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbForbiddenWordsList = new System.Windows.Forms.TextBox();
            this.btnUploadFromFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblForbiddenWordsList = new System.Windows.Forms.Label();
            this.btnConfirmWordsList = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGetStarted = new System.Windows.Forms.Button();
            this.lbSrchFiles = new System.Windows.Forms.ListBox();
            this.lblPleaseWait = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCountAllFiles = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbForbiddenWordsFiles = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblForbiddenWordsFilesCount = new System.Windows.Forms.Label();
            this.iblEditedFilesInfo = new System.Windows.Forms.Label();
            this.lbEditedFilesInfo = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnOpenReportFIle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter forbidden words (use comma to split it up):";
            // 
            // tbForbiddenWordsList
            // 
            this.tbForbiddenWordsList.Location = new System.Drawing.Point(331, 27);
            this.tbForbiddenWordsList.Name = "tbForbiddenWordsList";
            this.tbForbiddenWordsList.Size = new System.Drawing.Size(440, 22);
            this.tbForbiddenWordsList.TabIndex = 1;
            // 
            // btnUploadFromFile
            // 
            this.btnUploadFromFile.Location = new System.Drawing.Point(183, 71);
            this.btnUploadFromFile.Name = "btnUploadFromFile";
            this.btnUploadFromFile.Size = new System.Drawing.Size(126, 36);
            this.btnUploadFromFile.TabIndex = 2;
            this.btnUploadFromFile.Text = "Upload words";
            this.btnUploadFromFile.UseVisualStyleBackColor = true;
            this.btnUploadFromFile.Click += new System.EventHandler(this.BtnUploadFromFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Or upload them from file:";
            // 
            // lblForbiddenWordsList
            // 
            this.lblForbiddenWordsList.Location = new System.Drawing.Point(12, 137);
            this.lblForbiddenWordsList.Name = "lblForbiddenWordsList";
            this.lblForbiddenWordsList.Size = new System.Drawing.Size(164, 534);
            this.lblForbiddenWordsList.TabIndex = 4;
            // 
            // btnConfirmWordsList
            // 
            this.btnConfirmWordsList.Location = new System.Drawing.Point(789, 21);
            this.btnConfirmWordsList.Name = "btnConfirmWordsList";
            this.btnConfirmWordsList.Size = new System.Drawing.Size(85, 34);
            this.btnConfirmWordsList.TabIndex = 5;
            this.btnConfirmWordsList.Text = "Confirm";
            this.btnConfirmWordsList.UseVisualStyleBackColor = true;
            this.btnConfirmWordsList.Click += new System.EventHandler(this.BtnConfirmWordsList_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Forbidden words:";
            // 
            // btnGetStarted
            // 
            this.btnGetStarted.Location = new System.Drawing.Point(347, 71);
            this.btnGetStarted.Name = "btnGetStarted";
            this.btnGetStarted.Size = new System.Drawing.Size(158, 36);
            this.btnGetStarted.TabIndex = 2;
            this.btnGetStarted.Text = "Get Started";
            this.btnGetStarted.UseVisualStyleBackColor = true;
            this.btnGetStarted.Click += new System.EventHandler(this.BtnGetStarted_Click);
            // 
            // lbSrchFiles
            // 
            this.lbSrchFiles.FormattingEnabled = true;
            this.lbSrchFiles.HorizontalScrollbar = true;
            this.lbSrchFiles.ItemHeight = 16;
            this.lbSrchFiles.Location = new System.Drawing.Point(195, 189);
            this.lbSrchFiles.Name = "lbSrchFiles";
            this.lbSrchFiles.Size = new System.Drawing.Size(623, 148);
            this.lbSrchFiles.TabIndex = 8;
            // 
            // lblPleaseWait
            // 
            this.lblPleaseWait.AutoSize = true;
            this.lblPleaseWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPleaseWait.ForeColor = System.Drawing.Color.Red;
            this.lblPleaseWait.Location = new System.Drawing.Point(552, 71);
            this.lblPleaseWait.Name = "lblPleaseWait";
            this.lblPleaseWait.Size = new System.Drawing.Size(0, 20);
            this.lblPleaseWait.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(847, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Count:";
            // 
            // lblCountAllFiles
            // 
            this.lblCountAllFiles.AutoSize = true;
            this.lblCountAllFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCountAllFiles.Location = new System.Drawing.Point(847, 236);
            this.lblCountAllFiles.Name = "lblCountAllFiles";
            this.lblCountAllFiles.Size = new System.Drawing.Size(0, 25);
            this.lblCountAllFiles.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(193, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "All available files:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Files with forbidden words:";
            // 
            // lbForbiddenWordsFiles
            // 
            this.lbForbiddenWordsFiles.FormattingEnabled = true;
            this.lbForbiddenWordsFiles.HorizontalScrollbar = true;
            this.lbForbiddenWordsFiles.ItemHeight = 16;
            this.lbForbiddenWordsFiles.Location = new System.Drawing.Point(195, 381);
            this.lbForbiddenWordsFiles.Name = "lbForbiddenWordsFiles";
            this.lbForbiddenWordsFiles.Size = new System.Drawing.Size(623, 148);
            this.lbForbiddenWordsFiles.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(847, 392);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 25);
            this.label7.TabIndex = 10;
            this.label7.Text = "Count:";
            // 
            // lblForbiddenWordsFilesCount
            // 
            this.lblForbiddenWordsFilesCount.AutoSize = true;
            this.lblForbiddenWordsFilesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblForbiddenWordsFilesCount.Location = new System.Drawing.Point(847, 428);
            this.lblForbiddenWordsFilesCount.Name = "lblForbiddenWordsFilesCount";
            this.lblForbiddenWordsFilesCount.Size = new System.Drawing.Size(0, 25);
            this.lblForbiddenWordsFilesCount.TabIndex = 10;
            // 
            // iblEditedFilesInfo
            // 
            this.iblEditedFilesInfo.AutoSize = true;
            this.iblEditedFilesInfo.Location = new System.Drawing.Point(193, 551);
            this.iblEditedFilesInfo.Name = "iblEditedFilesInfo";
            this.iblEditedFilesInfo.Size = new System.Drawing.Size(59, 17);
            this.iblEditedFilesInfo.TabIndex = 3;
            this.iblEditedFilesInfo.Text = "Results:";
            // 
            // lbEditedFilesInfo
            // 
            this.lbEditedFilesInfo.FormattingEnabled = true;
            this.lbEditedFilesInfo.ItemHeight = 16;
            this.lbEditedFilesInfo.Location = new System.Drawing.Point(195, 571);
            this.lbEditedFilesInfo.Name = "lbEditedFilesInfo";
            this.lbEditedFilesInfo.Size = new System.Drawing.Size(623, 100);
            this.lbEditedFilesInfo.TabIndex = 8;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(701, 133);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(240, 32);
            this.progressBar.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(698, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Progress:";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(383, 120);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(66, 32);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(455, 120);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(88, 32);
            this.btnPause.TabIndex = 12;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(287, 120);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(90, 32);
            this.btnRestart.TabIndex = 12;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.BtnRestart_Click);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(549, 120);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(97, 32);
            this.btnResume.TabIndex = 12;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.BtnResume_Click);
            // 
            // btnOpenReportFIle
            // 
            this.btnOpenReportFIle.BackColor = System.Drawing.Color.Orange;
            this.btnOpenReportFIle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpenReportFIle.Location = new System.Drawing.Point(852, 571);
            this.btnOpenReportFIle.Name = "btnOpenReportFIle";
            this.btnOpenReportFIle.Size = new System.Drawing.Size(109, 83);
            this.btnOpenReportFIle.TabIndex = 13;
            this.btnOpenReportFIle.Text = "Open \r\nReport\r\nFIle";
            this.btnOpenReportFIle.UseVisualStyleBackColor = false;
            this.btnOpenReportFIle.Click += new System.EventHandler(this.BtnOpenReportFIle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 692);
            this.Controls.Add(this.btnOpenReportFIle);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblForbiddenWordsFilesCount);
            this.Controls.Add(this.lblCountAllFiles);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPleaseWait);
            this.Controls.Add(this.lbEditedFilesInfo);
            this.Controls.Add(this.lbForbiddenWordsFiles);
            this.Controls.Add(this.lbSrchFiles);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.iblEditedFilesInfo);
            this.Controls.Add(this.btnConfirmWordsList);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblForbiddenWordsList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGetStarted);
            this.Controls.Add(this.btnUploadFromFile);
            this.Controls.Add(this.tbForbiddenWordsList);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbForbiddenWordsList;
        private System.Windows.Forms.Button btnUploadFromFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblForbiddenWordsList;
        private System.Windows.Forms.Button btnConfirmWordsList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGetStarted;
        private System.Windows.Forms.ListBox lbSrchFiles;
        private System.Windows.Forms.Label lblPleaseWait;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCountAllFiles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbForbiddenWordsFiles;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblForbiddenWordsFilesCount;
        private System.Windows.Forms.Label iblEditedFilesInfo;
        private System.Windows.Forms.ListBox lbEditedFilesInfo;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnOpenReportFIle;
    }
}

