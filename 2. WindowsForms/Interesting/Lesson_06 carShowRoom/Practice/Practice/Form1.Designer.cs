namespace Practice
{
    partial class Form
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
            this.btnViewCar = new System.Windows.Forms.Button();
            this.btnDeleteCar = new System.Windows.Forms.Button();
            this.btnEditCar = new System.Windows.Forms.Button();
            this.btnAddCar = new System.Windows.Forms.Button();
            this.lbChooseCar = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnViewCar
            // 
            this.btnViewCar.BackColor = System.Drawing.Color.MistyRose;
            this.btnViewCar.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnViewCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnViewCar.ForeColor = System.Drawing.Color.Firebrick;
            this.btnViewCar.Location = new System.Drawing.Point(664, 392);
            this.btnViewCar.Name = "btnViewCar";
            this.btnViewCar.Size = new System.Drawing.Size(180, 61);
            this.btnViewCar.TabIndex = 3;
            this.btnViewCar.Text = "View car";
            this.btnViewCar.UseVisualStyleBackColor = false;
            this.btnViewCar.Click += new System.EventHandler(this.ChooseAction_Click);
            // 
            // btnDeleteCar
            // 
            this.btnDeleteCar.BackColor = System.Drawing.Color.MistyRose;
            this.btnDeleteCar.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnDeleteCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteCar.ForeColor = System.Drawing.Color.Firebrick;
            this.btnDeleteCar.Location = new System.Drawing.Point(664, 292);
            this.btnDeleteCar.Name = "btnDeleteCar";
            this.btnDeleteCar.Size = new System.Drawing.Size(180, 61);
            this.btnDeleteCar.TabIndex = 4;
            this.btnDeleteCar.Text = "Delete car";
            this.btnDeleteCar.UseVisualStyleBackColor = false;
            this.btnDeleteCar.Click += new System.EventHandler(this.ChooseAction_Click);
            // 
            // btnEditCar
            // 
            this.btnEditCar.BackColor = System.Drawing.Color.MistyRose;
            this.btnEditCar.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnEditCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditCar.ForeColor = System.Drawing.Color.Firebrick;
            this.btnEditCar.Location = new System.Drawing.Point(664, 190);
            this.btnEditCar.Name = "btnEditCar";
            this.btnEditCar.Size = new System.Drawing.Size(180, 61);
            this.btnEditCar.TabIndex = 5;
            this.btnEditCar.Text = "Edit car";
            this.btnEditCar.UseVisualStyleBackColor = false;
            this.btnEditCar.Click += new System.EventHandler(this.ChooseAction_Click);
            // 
            // btnAddCar
            // 
            this.btnAddCar.BackColor = System.Drawing.Color.MistyRose;
            this.btnAddCar.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnAddCar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddCar.ForeColor = System.Drawing.Color.Firebrick;
            this.btnAddCar.Location = new System.Drawing.Point(664, 89);
            this.btnAddCar.Name = "btnAddCar";
            this.btnAddCar.Size = new System.Drawing.Size(180, 61);
            this.btnAddCar.TabIndex = 6;
            this.btnAddCar.Text = "Add car";
            this.btnAddCar.UseVisualStyleBackColor = false;
            this.btnAddCar.Click += new System.EventHandler(this.ChooseAction_Click);
            // 
            // lbChooseCar
            // 
            this.lbChooseCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbChooseCar.ForeColor = System.Drawing.Color.Firebrick;
            this.lbChooseCar.FormattingEnabled = true;
            this.lbChooseCar.ItemHeight = 40;
            this.lbChooseCar.Location = new System.Drawing.Point(49, 89);
            this.lbChooseCar.Name = "lbChooseCar";
            this.lbChooseCar.Size = new System.Drawing.Size(553, 364);
            this.lbChooseCar.TabIndex = 2;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(920, 557);
            this.Controls.Add(this.btnViewCar);
            this.Controls.Add(this.btnDeleteCar);
            this.Controls.Add(this.btnEditCar);
            this.Controls.Add(this.btnAddCar);
            this.Controls.Add(this.lbChooseCar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car showroom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewCar;
        private System.Windows.Forms.Button btnDeleteCar;
        private System.Windows.Forms.Button btnEditCar;
        private System.Windows.Forms.Button btnAddCar;
        private System.Windows.Forms.ListBox lbChooseCar;
    }
}

