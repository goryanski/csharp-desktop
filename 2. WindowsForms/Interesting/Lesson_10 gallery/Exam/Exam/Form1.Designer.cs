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
            this.lbChoosePhoto = new System.Windows.Forms.ListBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.btnAddPhoto = new System.Windows.Forms.Button();
            this.btnEditPhoto = new System.Windows.Forms.Button();
            this.btnDeletePhoto = new System.Windows.Forms.Button();
            this.btnShowPhoto = new System.Windows.Forms.Button();
            this.btnFilterByCategory = new System.Windows.Forms.Button();
            this.cbCategoiesList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilterByDate = new System.Windows.Forms.Button();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.lblNotFound = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbChoosePhoto
            // 
            this.lbChoosePhoto.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbChoosePhoto.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbChoosePhoto.FormattingEnabled = true;
            this.lbChoosePhoto.ItemHeight = 29;
            this.lbChoosePhoto.Location = new System.Drawing.Point(19, 360);
            this.lbChoosePhoto.Name = "lbChoosePhoto";
            this.lbChoosePhoto.Size = new System.Drawing.Size(632, 265);
            this.lbChoosePhoto.TabIndex = 0;
            this.lbChoosePhoto.DoubleClick += new System.EventHandler(this.LbChoosePhoto_DoubleClick);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Orange;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Perpetua Titling MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnLogin.Location = new System.Drawing.Point(715, 32);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(163, 43);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Log in";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Tai Le", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(21, 308);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(460, 28);
            this.tbSearch.TabIndex = 2;
            this.tbSearch.TextChanged += new System.EventHandler(this.TbSearch_TextChanged);
            this.tbSearch.Enter += new System.EventHandler(this.TbSearch_Enter);
            this.tbSearch.Leave += new System.EventHandler(this.TbSearch_Leave);
            // 
            // btnRegistration
            // 
            this.btnRegistration.BackColor = System.Drawing.Color.Orange;
            this.btnRegistration.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistration.Font = new System.Drawing.Font("Perpetua Titling MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistration.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnRegistration.Location = new System.Drawing.Point(715, 98);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(163, 43);
            this.btnRegistration.TabIndex = 1;
            this.btnRegistration.Text = "Registration";
            this.btnRegistration.UseVisualStyleBackColor = false;
            this.btnRegistration.Click += new System.EventHandler(this.BtnRegistration_Click);
            // 
            // btnAddPhoto
            // 
            this.btnAddPhoto.BackColor = System.Drawing.Color.Orange;
            this.btnAddPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnAddPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPhoto.Font = new System.Drawing.Font("Perpetua Titling MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPhoto.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnAddPhoto.Location = new System.Drawing.Point(715, 360);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(163, 43);
            this.btnAddPhoto.TabIndex = 1;
            this.btnAddPhoto.Text = "Add photo";
            this.btnAddPhoto.UseVisualStyleBackColor = false;
            this.btnAddPhoto.Click += new System.EventHandler(this.BtnAddPhoto_Click);
            // 
            // btnEditPhoto
            // 
            this.btnEditPhoto.BackColor = System.Drawing.Color.Orange;
            this.btnEditPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnEditPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPhoto.Font = new System.Drawing.Font("Perpetua Titling MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPhoto.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnEditPhoto.Location = new System.Drawing.Point(715, 436);
            this.btnEditPhoto.Name = "btnEditPhoto";
            this.btnEditPhoto.Size = new System.Drawing.Size(163, 43);
            this.btnEditPhoto.TabIndex = 1;
            this.btnEditPhoto.Text = "Edit photo";
            this.btnEditPhoto.UseVisualStyleBackColor = false;
            this.btnEditPhoto.Click += new System.EventHandler(this.BtnEditPhoto_Click);
            // 
            // btnDeletePhoto
            // 
            this.btnDeletePhoto.BackColor = System.Drawing.Color.Orange;
            this.btnDeletePhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnDeletePhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePhoto.Font = new System.Drawing.Font("Perpetua Titling MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePhoto.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnDeletePhoto.Location = new System.Drawing.Point(715, 511);
            this.btnDeletePhoto.Name = "btnDeletePhoto";
            this.btnDeletePhoto.Size = new System.Drawing.Size(163, 43);
            this.btnDeletePhoto.TabIndex = 1;
            this.btnDeletePhoto.Text = "Delete photo";
            this.btnDeletePhoto.UseVisualStyleBackColor = false;
            this.btnDeletePhoto.Click += new System.EventHandler(this.BtnDeletePhoto_Click);
            // 
            // btnShowPhoto
            // 
            this.btnShowPhoto.BackColor = System.Drawing.Color.Orange;
            this.btnShowPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnShowPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPhoto.Font = new System.Drawing.Font("Perpetua Titling MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowPhoto.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnShowPhoto.Location = new System.Drawing.Point(715, 582);
            this.btnShowPhoto.Name = "btnShowPhoto";
            this.btnShowPhoto.Size = new System.Drawing.Size(163, 43);
            this.btnShowPhoto.TabIndex = 1;
            this.btnShowPhoto.Text = "Show photo";
            this.btnShowPhoto.UseVisualStyleBackColor = false;
            this.btnShowPhoto.Click += new System.EventHandler(this.BtnShowPhoto_Click);
            // 
            // btnFilterByCategory
            // 
            this.btnFilterByCategory.BackColor = System.Drawing.Color.Orange;
            this.btnFilterByCategory.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnFilterByCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterByCategory.Font = new System.Drawing.Font("Perpetua Titling MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterByCategory.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnFilterByCategory.Location = new System.Drawing.Point(21, 148);
            this.btnFilterByCategory.Name = "btnFilterByCategory";
            this.btnFilterByCategory.Size = new System.Drawing.Size(132, 69);
            this.btnFilterByCategory.TabIndex = 1;
            this.btnFilterByCategory.Text = "Filter by category";
            this.btnFilterByCategory.UseVisualStyleBackColor = false;
            this.btnFilterByCategory.Click += new System.EventHandler(this.BtnFilterByCategory_Click);
            // 
            // cbCategoiesList
            // 
            this.cbCategoiesList.Font = new System.Drawing.Font("Perpetua Titling MT", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoiesList.FormattingEnabled = true;
            this.cbCategoiesList.Location = new System.Drawing.Point(21, 104);
            this.cbCategoiesList.Name = "cbCategoiesList";
            this.cbCategoiesList.Size = new System.Drawing.Size(132, 27);
            this.cbCategoiesList.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(17, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select category and click button below:";
            // 
            // btnFilterByDate
            // 
            this.btnFilterByDate.BackColor = System.Drawing.Color.Orange;
            this.btnFilterByDate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnFilterByDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterByDate.Font = new System.Drawing.Font("Perpetua Titling MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterByDate.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnFilterByDate.Location = new System.Drawing.Point(496, 124);
            this.btnFilterByDate.Name = "btnFilterByDate";
            this.btnFilterByDate.Size = new System.Drawing.Size(108, 76);
            this.btnFilterByDate.TabIndex = 1;
            this.btnFilterByDate.Text = "Filter by date";
            this.btnFilterByDate.UseVisualStyleBackColor = false;
            this.btnFilterByDate.Click += new System.EventHandler(this.BtnFilterByDate_Click);
            this.btnFilterByDate.Leave += new System.EventHandler(this.BtnFilterByDate_Leave);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Location = new System.Drawing.Point(280, 124);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(201, 27);
            this.dtpFrom.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(282, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(322, 44);
            this.label2.TabIndex = 4;
            this.label2.Text = "Filter photos by upload date - select date from and date to, than click button be" +
    "low:\r\n";
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Location = new System.Drawing.Point(280, 167);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(201, 27);
            this.dtpTo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(235, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "from";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(252, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "to";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.BackColor = System.Drawing.Color.Orange;
            this.btnClearFilters.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue;
            this.btnClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilters.Font = new System.Drawing.Font("Perpetua Titling MT", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFilters.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnClearFilters.Location = new System.Drawing.Point(505, 290);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(146, 61);
            this.btnClearFilters.TabIndex = 1;
            this.btnClearFilters.Text = "Clear all filters";
            this.btnClearFilters.UseVisualStyleBackColor = false;
            this.btnClearFilters.Click += new System.EventHandler(this.BtnClearFilters_Click);
            // 
            // lblNotFound
            // 
            this.lblNotFound.AutoSize = true;
            this.lblNotFound.BackColor = System.Drawing.Color.White;
            this.lblNotFound.Font = new System.Drawing.Font("Perpetua Titling MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotFound.Location = new System.Drawing.Point(251, 483);
            this.lblNotFound.Name = "lblNotFound";
            this.lblNotFound.Size = new System.Drawing.Size(174, 29);
            this.lblNotFound.TabIndex = 7;
            this.lblNotFound.Text = "Not found";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(898, 644);
            this.Controls.Add(this.lblNotFound);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCategoiesList);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.btnShowPhoto);
            this.Controls.Add(this.btnDeletePhoto);
            this.Controls.Add(this.btnEditPhoto);
            this.Controls.Add(this.btnAddPhoto);
            this.Controls.Add(this.btnClearFilters);
            this.Controls.Add(this.btnFilterByDate);
            this.Controls.Add(this.btnFilterByCategory);
            this.Controls.Add(this.btnRegistration);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lbChoosePhoto);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbChoosePhoto;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnRegistration;
        private System.Windows.Forms.Button btnAddPhoto;
        private System.Windows.Forms.Button btnEditPhoto;
        private System.Windows.Forms.Button btnDeletePhoto;
        private System.Windows.Forms.Button btnShowPhoto;
        private System.Windows.Forms.Button btnFilterByCategory;
        private System.Windows.Forms.ComboBox cbCategoiesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFilterByDate;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.Label lblNotFound;
    }
}

