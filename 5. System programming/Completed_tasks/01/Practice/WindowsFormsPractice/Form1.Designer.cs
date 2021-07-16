
namespace WindowsFormsPractice
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnZhigul = new System.Windows.Forms.Button();
            this.btnLanos = new System.Windows.Forms.Button();
            this.btnPorsche = new System.Windows.Forms.Button();
            this.btnBmw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(34, 34);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(807, 194);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnStart.Location = new System.Drawing.Point(349, 263);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(159, 49);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(284, 396);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(296, 91);
            this.lblResult.TabIndex = 2;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnZhigul
            // 
            this.btnZhigul.BackColor = System.Drawing.Color.Fuchsia;
            this.btnZhigul.Location = new System.Drawing.Point(78, 56);
            this.btnZhigul.Name = "btnZhigul";
            this.btnZhigul.Size = new System.Drawing.Size(64, 32);
            this.btnZhigul.TabIndex = 3;
            this.btnZhigul.Text = "Zhigul";
            this.btnZhigul.UseVisualStyleBackColor = false;
            // 
            // btnLanos
            // 
            this.btnLanos.BackColor = System.Drawing.Color.Lime;
            this.btnLanos.Location = new System.Drawing.Point(78, 93);
            this.btnLanos.Name = "btnLanos";
            this.btnLanos.Size = new System.Drawing.Size(64, 32);
            this.btnLanos.TabIndex = 3;
            this.btnLanos.Text = "Lanos";
            this.btnLanos.UseVisualStyleBackColor = false;
            // 
            // btnPorsche
            // 
            this.btnPorsche.BackColor = System.Drawing.Color.Red;
            this.btnPorsche.Location = new System.Drawing.Point(78, 130);
            this.btnPorsche.Name = "btnPorsche";
            this.btnPorsche.Size = new System.Drawing.Size(64, 32);
            this.btnPorsche.TabIndex = 3;
            this.btnPorsche.Text = "Porsche";
            this.btnPorsche.UseVisualStyleBackColor = false;
            // 
            // btnBmw
            // 
            this.btnBmw.BackColor = System.Drawing.Color.Aqua;
            this.btnBmw.Location = new System.Drawing.Point(78, 167);
            this.btnBmw.Name = "btnBmw";
            this.btnBmw.Size = new System.Drawing.Size(64, 32);
            this.btnBmw.TabIndex = 3;
            this.btnBmw.Text = "Bmw";
            this.btnBmw.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 559);
            this.Controls.Add(this.btnBmw);
            this.Controls.Add(this.btnPorsche);
            this.Controls.Add(this.btnLanos);
            this.Controls.Add(this.btnZhigul);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnZhigul;
        private System.Windows.Forms.Button btnLanos;
        private System.Windows.Forms.Button btnPorsche;
        private System.Windows.Forms.Button btnBmw;
    }
}

