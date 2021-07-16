
namespace ShipsPractice
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
            this.lbAllShips = new System.Windows.Forms.ListBox();
            this.lbTunnel = new System.Windows.Forms.ListBox();
            this.lblBreadStock = new System.Windows.Forms.Label();
            this.lblBananasStock = new System.Windows.Forms.Label();
            this.lblClothesStock = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbAllShips
            // 
            this.lbAllShips.FormattingEnabled = true;
            this.lbAllShips.ItemHeight = 16;
            this.lbAllShips.Location = new System.Drawing.Point(202, 26);
            this.lbAllShips.Name = "lbAllShips";
            this.lbAllShips.Size = new System.Drawing.Size(299, 148);
            this.lbAllShips.TabIndex = 0;
            // 
            // lbTunnel
            // 
            this.lbTunnel.FormattingEnabled = true;
            this.lbTunnel.ItemHeight = 16;
            this.lbTunnel.Location = new System.Drawing.Point(265, 227);
            this.lbTunnel.Name = "lbTunnel";
            this.lbTunnel.Size = new System.Drawing.Size(156, 100);
            this.lbTunnel.TabIndex = 1;
            // 
            // lblBreadStock
            // 
            this.lblBreadStock.BackColor = System.Drawing.Color.LightCoral;
            this.lblBreadStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBreadStock.Location = new System.Drawing.Point(120, 406);
            this.lblBreadStock.Name = "lblBreadStock";
            this.lblBreadStock.Size = new System.Drawing.Size(78, 64);
            this.lblBreadStock.TabIndex = 2;
            this.lblBreadStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBananasStock
            // 
            this.lblBananasStock.BackColor = System.Drawing.Color.Khaki;
            this.lblBananasStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBananasStock.Location = new System.Drawing.Point(303, 406);
            this.lblBananasStock.Name = "lblBananasStock";
            this.lblBananasStock.Size = new System.Drawing.Size(78, 64);
            this.lblBananasStock.TabIndex = 2;
            this.lblBananasStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClothesStock
            // 
            this.lblClothesStock.BackColor = System.Drawing.Color.SteelBlue;
            this.lblClothesStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblClothesStock.Location = new System.Drawing.Point(502, 406);
            this.lblClothesStock.Name = "lblClothesStock";
            this.lblClothesStock.Size = new System.Drawing.Size(78, 64);
            this.lblClothesStock.TabIndex = 2;
            this.lblClothesStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 509);
            this.Controls.Add(this.lblClothesStock);
            this.Controls.Add(this.lblBananasStock);
            this.Controls.Add(this.lblBreadStock);
            this.Controls.Add(this.lbTunnel);
            this.Controls.Add(this.lbAllShips);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbAllShips;
        private System.Windows.Forms.ListBox lbTunnel;
        private System.Windows.Forms.Label lblBreadStock;
        private System.Windows.Forms.Label lblBananasStock;
        private System.Windows.Forms.Label lblClothesStock;
    }
}

