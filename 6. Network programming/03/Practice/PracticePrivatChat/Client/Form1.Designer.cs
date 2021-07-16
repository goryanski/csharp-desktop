
namespace Client
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
            this.rtbScreen = new System.Windows.Forms.RichTextBox();
            this.tbNickName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirmNick = new System.Windows.Forms.Button();
            this.btnSendForAll = new System.Windows.Forms.Button();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.lbMembers = new System.Windows.Forms.ListBox();
            this.btnPrivatSend = new System.Windows.Forms.Button();
            this.lblCountMembers = new System.Windows.Forms.Label();
            this.chBoxFileExists = new System.Windows.Forms.CheckBox();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbScreen
            // 
            this.rtbScreen.Location = new System.Drawing.Point(12, 12);
            this.rtbScreen.Name = "rtbScreen";
            this.rtbScreen.Size = new System.Drawing.Size(590, 275);
            this.rtbScreen.TabIndex = 10;
            this.rtbScreen.Text = "";
            // 
            // tbNickName
            // 
            this.tbNickName.Location = new System.Drawing.Point(13, 323);
            this.tbNickName.Name = "tbNickName";
            this.tbNickName.Size = new System.Drawing.Size(134, 22);
            this.tbNickName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "First write your nick:";
            // 
            // btnConfirmNick
            // 
            this.btnConfirmNick.Location = new System.Drawing.Point(74, 351);
            this.btnConfirmNick.Name = "btnConfirmNick";
            this.btnConfirmNick.Size = new System.Drawing.Size(73, 29);
            this.btnConfirmNick.TabIndex = 6;
            this.btnConfirmNick.Text = "Confirm";
            this.btnConfirmNick.UseVisualStyleBackColor = true;
            this.btnConfirmNick.Click += new System.EventHandler(this.BtnConfirmNick_Click);
            // 
            // btnSendForAll
            // 
            this.btnSendForAll.Location = new System.Drawing.Point(523, 376);
            this.btnSendForAll.Name = "btnSendForAll";
            this.btnSendForAll.Size = new System.Drawing.Size(79, 58);
            this.btnSendForAll.TabIndex = 7;
            this.btnSendForAll.Text = "Send\r\nfor all";
            this.btnSendForAll.UseVisualStyleBackColor = true;
            this.btnSendForAll.Click += new System.EventHandler(this.BtnSendForAll_Click);
            // 
            // rtbMessage
            // 
            this.rtbMessage.Location = new System.Drawing.Point(165, 303);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.Size = new System.Drawing.Size(352, 131);
            this.rtbMessage.TabIndex = 5;
            this.rtbMessage.Text = "";
            // 
            // lbMembers
            // 
            this.lbMembers.FormattingEnabled = true;
            this.lbMembers.ItemHeight = 16;
            this.lbMembers.Location = new System.Drawing.Point(621, 126);
            this.lbMembers.Name = "lbMembers";
            this.lbMembers.Size = new System.Drawing.Size(166, 308);
            this.lbMembers.TabIndex = 11;
            // 
            // btnPrivatSend
            // 
            this.btnPrivatSend.Location = new System.Drawing.Point(523, 303);
            this.btnPrivatSend.Name = "btnPrivatSend";
            this.btnPrivatSend.Size = new System.Drawing.Size(79, 59);
            this.btnPrivatSend.TabIndex = 7;
            this.btnPrivatSend.Text = "Private\r\nSend";
            this.btnPrivatSend.UseVisualStyleBackColor = true;
            this.btnPrivatSend.Click += new System.EventHandler(this.BtnPrivatSend_Click);
            // 
            // lblCountMembers
            // 
            this.lblCountMembers.AutoSize = true;
            this.lblCountMembers.Location = new System.Drawing.Point(618, 101);
            this.lblCountMembers.Name = "lblCountMembers";
            this.lblCountMembers.Size = new System.Drawing.Size(0, 17);
            this.lblCountMembers.TabIndex = 8;
            // 
            // chBoxFileExists
            // 
            this.chBoxFileExists.AutoSize = true;
            this.chBoxFileExists.Location = new System.Drawing.Point(13, 376);
            this.chBoxFileExists.Name = "chBoxFileExists";
            this.chBoxFileExists.Size = new System.Drawing.Size(18, 17);
            this.chBoxFileExists.TabIndex = 15;
            this.chBoxFileExists.UseVisualStyleBackColor = true;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(12, 395);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(134, 39);
            this.btnChooseFile.TabIndex = 14;
            this.btnChooseFile.Text = "Choose file";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.BtnChooseFile_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(621, 12);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(163, 63);
            this.btnFile.TabIndex = 16;
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.BtnFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 444);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.chBoxFileExists);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.lbMembers);
            this.Controls.Add(this.rtbScreen);
            this.Controls.Add(this.tbNickName);
            this.Controls.Add(this.lblCountMembers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirmNick);
            this.Controls.Add(this.btnPrivatSend);
            this.Controls.Add(this.btnSendForAll);
            this.Controls.Add(this.rtbMessage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbScreen;
        private System.Windows.Forms.TextBox tbNickName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirmNick;
        private System.Windows.Forms.Button btnSendForAll;
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.ListBox lbMembers;
        private System.Windows.Forms.Button btnPrivatSend;
        private System.Windows.Forms.Label lblCountMembers;
        private System.Windows.Forms.CheckBox chBoxFileExists;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnFile;
    }
}

