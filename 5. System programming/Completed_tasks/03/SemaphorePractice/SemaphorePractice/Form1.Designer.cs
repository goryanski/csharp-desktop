
namespace SemaphorePractice
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
            this.lbRunningThreads = new System.Windows.Forms.ListBox();
            this.lbWaitingThreads = new System.Windows.Forms.ListBox();
            this.lbCreatedThreads = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudCountPlaces = new System.Windows.Forms.NumericUpDown();
            this.btnCreateThread = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudCountPlaces)).BeginInit();
            this.SuspendLayout();
            // 
            // lbRunningThreads
            // 
            this.lbRunningThreads.FormattingEnabled = true;
            this.lbRunningThreads.ItemHeight = 16;
            this.lbRunningThreads.Location = new System.Drawing.Point(32, 62);
            this.lbRunningThreads.Name = "lbRunningThreads";
            this.lbRunningThreads.Size = new System.Drawing.Size(144, 116);
            this.lbRunningThreads.TabIndex = 0;
            this.lbRunningThreads.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LbRunningThreads_MouseDoubleClick);
            // 
            // lbWaitingThreads
            // 
            this.lbWaitingThreads.FormattingEnabled = true;
            this.lbWaitingThreads.ItemHeight = 16;
            this.lbWaitingThreads.Location = new System.Drawing.Point(217, 62);
            this.lbWaitingThreads.Name = "lbWaitingThreads";
            this.lbWaitingThreads.Size = new System.Drawing.Size(134, 116);
            this.lbWaitingThreads.TabIndex = 0;
            // 
            // lbCreatedThreads
            // 
            this.lbCreatedThreads.FormattingEnabled = true;
            this.lbCreatedThreads.ItemHeight = 16;
            this.lbCreatedThreads.Location = new System.Drawing.Point(390, 62);
            this.lbCreatedThreads.Name = "lbCreatedThreads";
            this.lbCreatedThreads.Size = new System.Drawing.Size(144, 116);
            this.lbCreatedThreads.TabIndex = 0;
            this.lbCreatedThreads.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LbCreatedThreads_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Running threads";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(214, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Waiting threads";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(398, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Created threads";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(29, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "Amount of places";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudCountPlaces
            // 
            this.nudCountPlaces.Location = new System.Drawing.Point(69, 237);
            this.nudCountPlaces.Margin = new System.Windows.Forms.Padding(4);
            this.nudCountPlaces.Name = "nudCountPlaces";
            this.nudCountPlaces.Size = new System.Drawing.Size(56, 22);
            this.nudCountPlaces.TabIndex = 5;
            this.nudCountPlaces.ValueChanged += new System.EventHandler(this.NudCountPlaces_ValueChanged);
            // 
            // btnCreateThread
            // 
            this.btnCreateThread.Location = new System.Drawing.Point(303, 226);
            this.btnCreateThread.Name = "btnCreateThread";
            this.btnCreateThread.Size = new System.Drawing.Size(144, 42);
            this.btnCreateThread.TabIndex = 6;
            this.btnCreateThread.Text = "Create thread";
            this.btnCreateThread.UseVisualStyleBackColor = true;
            this.btnCreateThread.Click += new System.EventHandler(this.BtnCreateThread_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 291);
            this.Controls.Add(this.btnCreateThread);
            this.Controls.Add(this.nudCountPlaces);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCreatedThreads);
            this.Controls.Add(this.lbWaitingThreads);
            this.Controls.Add(this.lbRunningThreads);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudCountPlaces)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbRunningThreads;
        private System.Windows.Forms.ListBox lbWaitingThreads;
        private System.Windows.Forms.ListBox lbCreatedThreads;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudCountPlaces;
        private System.Windows.Forms.Button btnCreateThread;
    }
}

