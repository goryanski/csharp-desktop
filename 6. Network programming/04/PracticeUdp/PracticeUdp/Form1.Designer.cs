
namespace PracticeUdp
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
            this.chBoxFileExists = new System.Windows.Forms.CheckBox();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.rtbScreen = new System.Windows.Forms.RichTextBox();
            this.tbNickName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConfirmNick = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.cbMembers = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // chBoxFileExists
            // 
            this.chBoxFileExists.AutoSize = true;
            this.chBoxFileExists.Location = new System.Drawing.Point(16, 367);
            this.chBoxFileExists.Name = "chBoxFileExists";
            this.chBoxFileExists.Size = new System.Drawing.Size(18, 17);
            this.chBoxFileExists.TabIndex = 27;
            this.chBoxFileExists.UseVisualStyleBackColor = true;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(15, 386);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(134, 39);
            this.btnChooseFile.TabIndex = 26;
            this.btnChooseFile.Text = "Choose file";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.BtnChooseFile_Click);
            // 
            // rtbScreen
            // 
            this.rtbScreen.Location = new System.Drawing.Point(12, 7);
            this.rtbScreen.Name = "rtbScreen";
            this.rtbScreen.Size = new System.Drawing.Size(590, 275);
            this.rtbScreen.TabIndex = 24;
            this.rtbScreen.Text = "";
            // 
            // tbNickName
            // 
            this.tbNickName.Location = new System.Drawing.Point(16, 314);
            this.tbNickName.Name = "tbNickName";
            this.tbNickName.Size = new System.Drawing.Size(134, 22);
            this.tbNickName.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "First write your nick:";
            // 
            // btnConfirmNick
            // 
            this.btnConfirmNick.Location = new System.Drawing.Point(77, 342);
            this.btnConfirmNick.Name = "btnConfirmNick";
            this.btnConfirmNick.Size = new System.Drawing.Size(73, 29);
            this.btnConfirmNick.TabIndex = 18;
            this.btnConfirmNick.Text = "Confirm";
            this.btnConfirmNick.UseVisualStyleBackColor = true;
            this.btnConfirmNick.Click += new System.EventHandler(this.BtnConfirmNick_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(653, 342);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(79, 59);
            this.btnSend.TabIndex = 19;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // rtbMessage
            // 
            this.rtbMessage.Location = new System.Drawing.Point(165, 298);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.Size = new System.Drawing.Size(437, 131);
            this.rtbMessage.TabIndex = 17;
            this.rtbMessage.Text = "";
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(644, 38);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(163, 63);
            this.btnFile.TabIndex = 28;
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.BtnFile_Click);
            // 
            // cbMembers
            // 
            this.cbMembers.FormattingEnabled = true;
            this.cbMembers.Location = new System.Drawing.Point(664, 149);
            this.cbMembers.Name = "cbMembers";
            this.cbMembers.Size = new System.Drawing.Size(121, 24);
            this.cbMembers.TabIndex = 29;
            this.cbMembers.Text = "Members";
            this.cbMembers.Click += new System.EventHandler(this.CbMembers_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 442);
            this.Controls.Add(this.cbMembers);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.chBoxFileExists);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.rtbScreen);
            this.Controls.Add(this.tbNickName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConfirmNick);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rtbMessage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chBoxFileExists;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.RichTextBox rtbScreen;
        private System.Windows.Forms.TextBox tbNickName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConfirmNick;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.ComboBox cbMembers;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

