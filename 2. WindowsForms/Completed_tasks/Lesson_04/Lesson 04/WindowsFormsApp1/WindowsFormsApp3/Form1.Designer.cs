namespace WindowsFormsApp3
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
            this.gbEditor = new System.Windows.Forms.GroupBox();
            this.cbRightAnswer = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.nudMinutesCount = new System.Windows.Forms.NumericUpDown();
            this.tbAnswer = new System.Windows.Forms.TextBox();
            this.tbQuestion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTestName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbChoose = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAnswerChoose = new System.Windows.Forms.ListBox();
            this.lbQuestionChoose = new System.Windows.Forms.ListBox();
            this.lbTestChoose = new System.Windows.Forms.ListBox();
            this.gbEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutesCount)).BeginInit();
            this.gbChoose.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEditor
            // 
            this.gbEditor.BackColor = System.Drawing.Color.PowderBlue;
            this.gbEditor.Controls.Add(this.cbRightAnswer);
            this.gbEditor.Controls.Add(this.buttonSave);
            this.gbEditor.Controls.Add(this.nudMinutesCount);
            this.gbEditor.Controls.Add(this.tbAnswer);
            this.gbEditor.Controls.Add(this.tbQuestion);
            this.gbEditor.Controls.Add(this.label6);
            this.gbEditor.Controls.Add(this.tbTestName);
            this.gbEditor.Controls.Add(this.label5);
            this.gbEditor.Controls.Add(this.label4);
            this.gbEditor.Controls.Add(this.label3);
            this.gbEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbEditor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.gbEditor.Location = new System.Drawing.Point(504, 12);
            this.gbEditor.Name = "gbEditor";
            this.gbEditor.Size = new System.Drawing.Size(490, 565);
            this.gbEditor.TabIndex = 2;
            this.gbEditor.TabStop = false;
            this.gbEditor.Text = "Edit test:";
            // 
            // cbRightAnswer
            // 
            this.cbRightAnswer.AutoSize = true;
            this.cbRightAnswer.Location = new System.Drawing.Point(37, 412);
            this.cbRightAnswer.Name = "cbRightAnswer";
            this.cbRightAnswer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbRightAnswer.Size = new System.Drawing.Size(161, 26);
            this.cbRightAnswer.TabIndex = 4;
            this.cbRightAnswer.Text = "It\'s right answer";
            this.cbRightAnswer.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.DarkGray;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(212, 497);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(250, 54);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // nudMinutesCount
            // 
            this.nudMinutesCount.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMinutesCount.Location = new System.Drawing.Point(279, 124);
            this.nudMinutesCount.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.nudMinutesCount.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMinutesCount.Name = "nudMinutesCount";
            this.nudMinutesCount.Size = new System.Drawing.Size(183, 28);
            this.nudMinutesCount.TabIndex = 2;
            this.nudMinutesCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // tbAnswer
            // 
            this.tbAnswer.Location = new System.Drawing.Point(212, 344);
            this.tbAnswer.Multiline = true;
            this.tbAnswer.Name = "tbAnswer";
            this.tbAnswer.Size = new System.Drawing.Size(250, 94);
            this.tbAnswer.TabIndex = 0;
            // 
            // tbQuestion
            // 
            this.tbQuestion.Location = new System.Drawing.Point(212, 218);
            this.tbQuestion.Multiline = true;
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.Size = new System.Drawing.Size(250, 94);
            this.tbQuestion.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 22);
            this.label6.TabIndex = 1;
            this.label6.Text = "Change answer:";
            // 
            // tbTestName
            // 
            this.tbTestName.Location = new System.Drawing.Point(233, 53);
            this.tbTestName.Name = "tbTestName";
            this.tbTestName.Size = new System.Drawing.Size(229, 28);
            this.tbTestName.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "Change question:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "Change minutes count:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "Change test name:";
            // 
            // gbChoose
            // 
            this.gbChoose.BackColor = System.Drawing.Color.PowderBlue;
            this.gbChoose.Controls.Add(this.label2);
            this.gbChoose.Controls.Add(this.label1);
            this.gbChoose.Controls.Add(this.lbAnswerChoose);
            this.gbChoose.Controls.Add(this.lbQuestionChoose);
            this.gbChoose.Controls.Add(this.lbTestChoose);
            this.gbChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbChoose.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.gbChoose.Location = new System.Drawing.Point(12, 12);
            this.gbChoose.Name = "gbChoose";
            this.gbChoose.Size = new System.Drawing.Size(470, 565);
            this.gbChoose.TabIndex = 2;
            this.gbChoose.TabStop = false;
            this.gbChoose.Text = "Choose test:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 389);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Choose answer:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose question:";
            // 
            // lbAnswerChoose
            // 
            this.lbAnswerChoose.FormattingEnabled = true;
            this.lbAnswerChoose.ItemHeight = 22;
            this.lbAnswerChoose.Location = new System.Drawing.Point(23, 415);
            this.lbAnswerChoose.Name = "lbAnswerChoose";
            this.lbAnswerChoose.Size = new System.Drawing.Size(420, 136);
            this.lbAnswerChoose.TabIndex = 0;
            this.lbAnswerChoose.SelectedIndexChanged += new System.EventHandler(this.LbAnswerChoose_SelectedIndexChanged);
            // 
            // lbQuestionChoose
            // 
            this.lbQuestionChoose.FormattingEnabled = true;
            this.lbQuestionChoose.ItemHeight = 22;
            this.lbQuestionChoose.Location = new System.Drawing.Point(23, 225);
            this.lbQuestionChoose.Name = "lbQuestionChoose";
            this.lbQuestionChoose.Size = new System.Drawing.Size(420, 136);
            this.lbQuestionChoose.TabIndex = 0;
            this.lbQuestionChoose.SelectedIndexChanged += new System.EventHandler(this.LbQuestionChoose_SelectedIndexChanged);
            // 
            // lbTestChoose
            // 
            this.lbTestChoose.FormattingEnabled = true;
            this.lbTestChoose.ItemHeight = 22;
            this.lbTestChoose.Location = new System.Drawing.Point(23, 53);
            this.lbTestChoose.Name = "lbTestChoose";
            this.lbTestChoose.Size = new System.Drawing.Size(420, 114);
            this.lbTestChoose.TabIndex = 0;
            this.lbTestChoose.SelectedIndexChanged += new System.EventHandler(this.LbTestChoose_SelectedIndexChanged);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1006, 589);
            this.Controls.Add(this.gbChoose);
            this.Controls.Add(this.gbEditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.gbEditor.ResumeLayout(false);
            this.gbEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutesCount)).EndInit();
            this.gbChoose.ResumeLayout(false);
            this.gbChoose.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbEditor;
        private System.Windows.Forms.GroupBox gbChoose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbAnswerChoose;
        private System.Windows.Forms.ListBox lbQuestionChoose;
        private System.Windows.Forms.ListBox lbTestChoose;
        private System.Windows.Forms.TextBox tbTestName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudMinutesCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbQuestion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbAnswer;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox cbRightAnswer;
    }
}

