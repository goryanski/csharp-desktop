
namespace SmtpPractice
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
            this.tbDestination = new System.Windows.Forms.TextBox();
            this.tblTheme = new System.Windows.Forms.TextBox();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblTheme = new System.Windows.Forms.Label();
            this.lblMessageText = new System.Windows.Forms.Label();
            this.rbxMessageText = new System.Windows.Forms.RichTextBox();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblSendInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbDestination
            // 
            this.tbDestination.Location = new System.Drawing.Point(169, 26);
            this.tbDestination.Name = "tbDestination";
            this.tbDestination.Size = new System.Drawing.Size(229, 22);
            this.tbDestination.TabIndex = 0;
            // 
            // tblTheme
            // 
            this.tblTheme.Location = new System.Drawing.Point(169, 77);
            this.tblTheme.Name = "tblTheme";
            this.tblTheme.Size = new System.Drawing.Size(229, 22);
            this.tblTheme.TabIndex = 0;
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(13, 31);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(139, 17);
            this.lblDestination.TabIndex = 1;
            this.lblDestination.Text = "Enter email-address:";
            // 
            // lblTheme
            // 
            this.lblTheme.AutoSize = true;
            this.lblTheme.Location = new System.Drawing.Point(13, 80);
            this.lblTheme.Name = "lblTheme";
            this.lblTheme.Size = new System.Drawing.Size(150, 17);
            this.lblTheme.TabIndex = 1;
            this.lblTheme.Text = "Enter message theme:";
            // 
            // lblMessageText
            // 
            this.lblMessageText.AutoSize = true;
            this.lblMessageText.Location = new System.Drawing.Point(13, 130);
            this.lblMessageText.Name = "lblMessageText";
            this.lblMessageText.Size = new System.Drawing.Size(133, 17);
            this.lblMessageText.TabIndex = 1;
            this.lblMessageText.Text = "Enter message text:";
            // 
            // rbxMessageText
            // 
            this.rbxMessageText.Location = new System.Drawing.Point(169, 130);
            this.rbxMessageText.Name = "rbxMessageText";
            this.rbxMessageText.Size = new System.Drawing.Size(229, 114);
            this.rbxMessageText.TabIndex = 2;
            this.rbxMessageText.Text = "";
            this.rbxMessageText.TextChanged += new System.EventHandler(this.RbxMessageText_TextChanged);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(122, 315);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(96, 39);
            this.btnChooseFile.TabIndex = 3;
            this.btnChooseFile.Text = "Choose file";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.BtnChooseFile_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(302, 315);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(96, 39);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // lblSendInfo
            // 
            this.lblSendInfo.AutoSize = true;
            this.lblSendInfo.ForeColor = System.Drawing.Color.Red;
            this.lblSendInfo.Location = new System.Drawing.Point(361, 247);
            this.lblSendInfo.Name = "lblSendInfo";
            this.lblSendInfo.Size = new System.Drawing.Size(37, 17);
            this.lblSendInfo.TabIndex = 4;
            this.lblSendInfo.Text = "Sent";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 376);
            this.Controls.Add(this.lblSendInfo);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.rbxMessageText);
            this.Controls.Add(this.lblMessageText);
            this.Controls.Add(this.lblTheme);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.tblTheme);
            this.Controls.Add(this.tbDestination);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDestination;
        private System.Windows.Forms.TextBox tblTheme;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Label lblTheme;
        private System.Windows.Forms.Label lblMessageText;
        private System.Windows.Forms.RichTextBox rbxMessageText;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblSendInfo;
    }
}

