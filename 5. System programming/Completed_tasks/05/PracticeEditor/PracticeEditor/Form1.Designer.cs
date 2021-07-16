
namespace PracticeEditor
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
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.editPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAge = new System.Windows.Forms.TextBox();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.lbWait = new System.Windows.Forms.Label();
            this.editPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.ItemHeight = 16;
            this.lbUsers.Location = new System.Drawing.Point(25, 23);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(283, 196);
            this.lbUsers.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(326, 23);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(91, 69);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "EDIT";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // editPanel
            // 
            this.editPanel.Controls.Add(this.label2);
            this.editPanel.Controls.Add(this.btnSave);
            this.editPanel.Controls.Add(this.label1);
            this.editPanel.Controls.Add(this.tbAge);
            this.editPanel.Controls.Add(this.tbFullName);
            this.editPanel.Location = new System.Drawing.Point(25, 262);
            this.editPanel.Name = "editPanel";
            this.editPanel.Size = new System.Drawing.Size(283, 167);
            this.editPanel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Age:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(110, 119);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // tbAge
            // 
            this.tbAge.Location = new System.Drawing.Point(110, 68);
            this.tbAge.Name = "tbAge";
            this.tbAge.Size = new System.Drawing.Size(131, 22);
            this.tbAge.TabIndex = 0;
            // 
            // tbFullName
            // 
            this.tbFullName.Location = new System.Drawing.Point(110, 26);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(131, 22);
            this.tbFullName.TabIndex = 0;
            // 
            // lbWait
            // 
            this.lbWait.AutoSize = true;
            this.lbWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbWait.ForeColor = System.Drawing.Color.Red;
            this.lbWait.Location = new System.Drawing.Point(94, 226);
            this.lbWait.Name = "lbWait";
            this.lbWait.Size = new System.Drawing.Size(137, 29);
            this.lbWait.TabIndex = 1;
            this.lbWait.Text = "Please wait";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 441);
            this.Controls.Add(this.editPanel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lbWait);
            this.Controls.Add(this.lbUsers);
            this.Name = "Form1";
            this.Text = "Form1";
            this.editPanel.ResumeLayout(false);
            this.editPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel editPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAge;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.Label lbWait;
    }
}

