namespace Exam.forms
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.btnClearPathField = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbNoPicture = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbImagePath = new System.Windows.Forms.TextBox();
            this.tbImageCategory = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbImageName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.Color.NavajoWhite;
            this.pbImage.Location = new System.Drawing.Point(479, 48);
            this.pbImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(218, 199);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 26;
            this.pbImage.TabStop = false;
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.BackColor = System.Drawing.Color.Orange;
            this.btnOpenImage.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnOpenImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenImage.Font = new System.Drawing.Font("Perpetua Titling MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenImage.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnOpenImage.Location = new System.Drawing.Point(479, 312);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(218, 43);
            this.btnOpenImage.TabIndex = 25;
            this.btnOpenImage.Text = "Open image";
            this.btnOpenImage.UseVisualStyleBackColor = false;
            this.btnOpenImage.Click += new System.EventHandler(this.BtnOpenImage_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Orange;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Perpetua Titling MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnSave.Location = new System.Drawing.Point(479, 541);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 59);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.BackColor = System.Drawing.Color.Orange;
            this.btnAddImage.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddImage.Font = new System.Drawing.Font("Perpetua Titling MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnAddImage.Location = new System.Drawing.Point(241, 358);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(128, 59);
            this.btnAddImage.TabIndex = 23;
            this.btnAddImage.Text = "Add image";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.BtnAddImage_Click);
            // 
            // btnClearPathField
            // 
            this.btnClearPathField.BackColor = System.Drawing.Color.Orange;
            this.btnClearPathField.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnClearPathField.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearPathField.Font = new System.Drawing.Font("Perpetua Titling MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearPathField.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnClearPathField.Location = new System.Drawing.Point(62, 358);
            this.btnClearPathField.Name = "btnClearPathField";
            this.btnClearPathField.Size = new System.Drawing.Size(128, 59);
            this.btnClearPathField.TabIndex = 22;
            this.btnClearPathField.Text = "Clear path field";
            this.btnClearPathField.UseVisualStyleBackColor = false;
            this.btnClearPathField.Click += new System.EventHandler(this.BtnClearPathField_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Orange;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Perpetua Titling MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnCancel.Location = new System.Drawing.Point(252, 541);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 59);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // cbNoPicture
            // 
            this.cbNoPicture.AutoSize = true;
            this.cbNoPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbNoPicture.ForeColor = System.Drawing.Color.DarkBlue;
            this.cbNoPicture.Location = new System.Drawing.Point(528, 393);
            this.cbNoPicture.Name = "cbNoPicture";
            this.cbNoPicture.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbNoPicture.Size = new System.Drawing.Size(173, 24);
            this.cbNoPicture.TabIndex = 20;
            this.cbNoPicture.Text = "Save without image";
            this.cbNoPicture.UseVisualStyleBackColor = true;
            this.cbNoPicture.CheckedChanged += new System.EventHandler(this.CbNoPicture_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.NavajoWhite;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.DarkBlue;
            this.label8.Location = new System.Drawing.Point(412, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 22);
            this.label8.TabIndex = 18;
            this.label8.Text = "or";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.NavajoWhite;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(58, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 22);
            this.label7.TabIndex = 19;
            this.label7.Text = "Image path: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.NavajoWhite;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(58, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 22);
            this.label3.TabIndex = 16;
            this.label3.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.NavajoWhite;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(75, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 22);
            this.label4.TabIndex = 14;
            this.label4.Text = "Category:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.NavajoWhite;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(52, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "Photo name:";
            // 
            // tbImagePath
            // 
            this.tbImagePath.ForeColor = System.Drawing.Color.DarkBlue;
            this.tbImagePath.Location = new System.Drawing.Point(175, 312);
            this.tbImagePath.Name = "tbImagePath";
            this.tbImagePath.Size = new System.Drawing.Size(194, 26);
            this.tbImagePath.TabIndex = 11;
            // 
            // tbImageCategory
            // 
            this.tbImageCategory.ForeColor = System.Drawing.Color.DarkBlue;
            this.tbImageCategory.Location = new System.Drawing.Point(175, 92);
            this.tbImageCategory.Name = "tbImageCategory";
            this.tbImageCategory.Size = new System.Drawing.Size(194, 26);
            this.tbImageCategory.TabIndex = 8;
            // 
            // tbDescription
            // 
            this.tbDescription.ForeColor = System.Drawing.Color.DarkBlue;
            this.tbDescription.Location = new System.Drawing.Point(175, 139);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(194, 108);
            this.tbDescription.TabIndex = 12;
            // 
            // tbImageName
            // 
            this.tbImageName.ForeColor = System.Drawing.Color.DarkBlue;
            this.tbImageName.Location = new System.Drawing.Point(175, 48);
            this.tbImageName.Name = "tbImageName";
            this.tbImageName.Size = new System.Drawing.Size(194, 26);
            this.tbImageName.TabIndex = 7;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(780, 647);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnOpenImage);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddImage);
            this.Controls.Add(this.btnClearPathField);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbNoPicture);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbImagePath);
            this.Controls.Add(this.tbImageCategory);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbImageName);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Name = "EditForm";
            this.Text = "EditForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.Button btnClearPathField;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbNoPicture;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbImagePath;
        private System.Windows.Forms.TextBox tbImageCategory;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbImageName;
    }
}