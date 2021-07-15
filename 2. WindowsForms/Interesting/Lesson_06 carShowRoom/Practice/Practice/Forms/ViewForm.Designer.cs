namespace Practice
{
    partial class ViewForm
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
            this.pbCarImage = new System.Windows.Forms.PictureBox();
            this.lblCarDescription = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCarImage
            // 
            this.pbCarImage.Location = new System.Drawing.Point(31, 22);
            this.pbCarImage.Name = "pbCarImage";
            this.pbCarImage.Size = new System.Drawing.Size(388, 281);
            this.pbCarImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCarImage.TabIndex = 4;
            this.pbCarImage.TabStop = false;
            // 
            // lblCarDescription
            // 
            this.lblCarDescription.BackColor = System.Drawing.Color.SeaShell;
            this.lblCarDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCarDescription.ForeColor = System.Drawing.Color.Firebrick;
            this.lblCarDescription.Location = new System.Drawing.Point(25, 349);
            this.lblCarDescription.Name = "lblCarDescription";
            this.lblCarDescription.Size = new System.Drawing.Size(392, 162);
            this.lblCarDescription.TabIndex = 5;
            this.lblCarDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.MistyRose;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOk.ForeColor = System.Drawing.Color.Firebrick;
            this.btnOk.Location = new System.Drawing.Point(173, 548);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(117, 59);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(451, 641);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblCarDescription);
            this.Controls.Add(this.pbCarImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ViewForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbCarImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbCarImage;
        private System.Windows.Forms.Label lblCarDescription;
        private System.Windows.Forms.Button btnOk;
    }
}