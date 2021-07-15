namespace Practice
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.topMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.topMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.topMenuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuPast = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuFont = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuTextColor = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuBackColor = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleIncrease = new System.Windows.Forms.ToolStripMenuItem();
            this.scaleDecrease = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMenuShowInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuPast = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ScaleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSalmon;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(932, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topMenuOpen,
            this.toolStripSeparator1,
            this.topMenuSave,
            this.topMenuSaveAs,
            this.topMenuPrint,
            this.toolStripSeparator2,
            this.topMenuExit});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(56, 32);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // topMenuOpen
            // 
            this.topMenuOpen.Name = "topMenuOpen";
            this.topMenuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.topMenuOpen.Size = new System.Drawing.Size(286, 34);
            this.topMenuOpen.Text = "Open";
            this.topMenuOpen.Click += new System.EventHandler(this.TopMenuOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(283, 6);
            // 
            // topMenuSave
            // 
            this.topMenuSave.Name = "topMenuSave";
            this.topMenuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.topMenuSave.Size = new System.Drawing.Size(286, 34);
            this.topMenuSave.Text = "Save";
            this.topMenuSave.Click += new System.EventHandler(this.TopMenuSave_Click);
            // 
            // topMenuSaveAs
            // 
            this.topMenuSaveAs.Name = "topMenuSaveAs";
            this.topMenuSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.topMenuSaveAs.Size = new System.Drawing.Size(286, 34);
            this.topMenuSaveAs.Text = "Save as";
            this.topMenuSaveAs.Click += new System.EventHandler(this.TopMenuSaveAs_Click);
            // 
            // topMenuPrint
            // 
            this.topMenuPrint.Name = "topMenuPrint";
            this.topMenuPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.topMenuPrint.Size = new System.Drawing.Size(286, 34);
            this.topMenuPrint.Text = "Print";
            this.topMenuPrint.Click += new System.EventHandler(this.TopMenuPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(283, 6);
            // 
            // topMenuExit
            // 
            this.topMenuExit.Name = "topMenuExit";
            this.topMenuExit.Size = new System.Drawing.Size(286, 34);
            this.topMenuExit.Text = "Exit";
            this.topMenuExit.Click += new System.EventHandler(this.TopMenuExit_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topMenuUndo,
            this.toolStripSeparator4,
            this.topMenuCut,
            this.topMenuCopy,
            this.topMenuPast,
            this.topMenuDelete,
            this.topMenuSelectAll});
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(58, 32);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // topMenuUndo
            // 
            this.topMenuUndo.Name = "topMenuUndo";
            this.topMenuUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.topMenuUndo.Size = new System.Drawing.Size(253, 34);
            this.topMenuUndo.Text = "Undo";
            this.topMenuUndo.Click += new System.EventHandler(this.ContextMenuUndo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(250, 6);
            // 
            // topMenuCut
            // 
            this.topMenuCut.Name = "topMenuCut";
            this.topMenuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.topMenuCut.Size = new System.Drawing.Size(253, 34);
            this.topMenuCut.Text = "Cut";
            this.topMenuCut.Click += new System.EventHandler(this.ContextMenuCut_Click);
            // 
            // topMenuCopy
            // 
            this.topMenuCopy.Name = "topMenuCopy";
            this.topMenuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.topMenuCopy.Size = new System.Drawing.Size(253, 34);
            this.topMenuCopy.Text = "Copy";
            this.topMenuCopy.Click += new System.EventHandler(this.ContextMenuCopy_Click);
            // 
            // topMenuPast
            // 
            this.topMenuPast.Name = "topMenuPast";
            this.topMenuPast.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.topMenuPast.Size = new System.Drawing.Size(253, 34);
            this.topMenuPast.Text = "Paste";
            this.topMenuPast.Click += new System.EventHandler(this.ContextMenuPaste_Click);
            // 
            // topMenuDelete
            // 
            this.topMenuDelete.Name = "topMenuDelete";
            this.topMenuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.topMenuDelete.Size = new System.Drawing.Size(253, 34);
            this.topMenuDelete.Text = "Delete";
            this.topMenuDelete.Click += new System.EventHandler(this.ContextMenuRemove_Click);
            // 
            // topMenuSelectAll
            // 
            this.topMenuSelectAll.Name = "topMenuSelectAll";
            this.topMenuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.topMenuSelectAll.Size = new System.Drawing.Size(253, 34);
            this.topMenuSelectAll.Text = "Select All";
            this.topMenuSelectAll.Click += new System.EventHandler(this.ContextMenuSelectAll_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topMenuFont,
            this.topMenuTextColor,
            this.topMenuBackColor});
            this.formatToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(86, 32);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // topMenuFont
            // 
            this.topMenuFont.Name = "topMenuFont";
            this.topMenuFont.Size = new System.Drawing.Size(197, 34);
            this.topMenuFont.Text = "Font";
            this.topMenuFont.Click += new System.EventHandler(this.TopMenuFont_Click);
            // 
            // topMenuTextColor
            // 
            this.topMenuTextColor.Name = "topMenuTextColor";
            this.topMenuTextColor.Size = new System.Drawing.Size(197, 34);
            this.topMenuTextColor.Text = "Text color";
            this.topMenuTextColor.Click += new System.EventHandler(this.TopMenuTextColor_Click);
            // 
            // topMenuBackColor
            // 
            this.topMenuBackColor.Name = "topMenuBackColor";
            this.topMenuBackColor.Size = new System.Drawing.Size(197, 34);
            this.topMenuBackColor.Text = "Back color";
            this.topMenuBackColor.Click += new System.EventHandler(this.TopMenuBackColor_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scaleToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(68, 32);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // scaleToolStripMenuItem
            // 
            this.scaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scaleIncrease,
            this.scaleDecrease});
            this.scaleToolStripMenuItem.Name = "scaleToolStripMenuItem";
            this.scaleToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.scaleToolStripMenuItem.Text = "Scale";
            // 
            // scaleIncrease
            // 
            this.scaleIncrease.Name = "scaleIncrease";
            this.scaleIncrease.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.scaleIncrease.Size = new System.Drawing.Size(328, 34);
            this.scaleIncrease.Text = "Increase";
            this.scaleIncrease.Click += new System.EventHandler(this.ScaleIncrease_Click);
            // 
            // scaleDecrease
            // 
            this.scaleDecrease.Name = "scaleDecrease";
            this.scaleDecrease.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.scaleDecrease.Size = new System.Drawing.Size(328, 34);
            this.scaleDecrease.Text = "Decrease";
            this.scaleDecrease.Click += new System.EventHandler(this.ScaleDecrease_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topMenuShowInfo});
            this.infoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(59, 32);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // topMenuShowInfo
            // 
            this.topMenuShowInfo.Name = "topMenuShowInfo";
            this.topMenuShowInfo.Size = new System.Drawing.Size(193, 34);
            this.topMenuShowInfo.Text = "Show info";
            this.topMenuShowInfo.Click += new System.EventHandler(this.TopMenuShowInfo_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.Location = new System.Drawing.Point(-4, 36);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(937, 604);
            this.richTextBox.TabIndex = 2;
            this.richTextBox.Text = "";
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuUndo,
            this.toolStripSeparator3,
            this.contextMenuCut,
            this.contextMenuCopy,
            this.contextMenuPast,
            this.contextMenuDelete,
            this.contextMenuSelectAll});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(156, 202);
            // 
            // contextMenuUndo
            // 
            this.contextMenuUndo.Name = "contextMenuUndo";
            this.contextMenuUndo.Size = new System.Drawing.Size(155, 32);
            this.contextMenuUndo.Text = "Undo";
            this.contextMenuUndo.Click += new System.EventHandler(this.ContextMenuUndo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(152, 6);
            // 
            // contextMenuCut
            // 
            this.contextMenuCut.Name = "contextMenuCut";
            this.contextMenuCut.Size = new System.Drawing.Size(155, 32);
            this.contextMenuCut.Text = "Cut";
            this.contextMenuCut.Click += new System.EventHandler(this.ContextMenuCut_Click);
            // 
            // contextMenuCopy
            // 
            this.contextMenuCopy.Name = "contextMenuCopy";
            this.contextMenuCopy.Size = new System.Drawing.Size(155, 32);
            this.contextMenuCopy.Text = "Copy";
            this.contextMenuCopy.Click += new System.EventHandler(this.ContextMenuCopy_Click);
            // 
            // contextMenuPast
            // 
            this.contextMenuPast.Name = "contextMenuPast";
            this.contextMenuPast.Size = new System.Drawing.Size(155, 32);
            this.contextMenuPast.Text = "Paste";
            this.contextMenuPast.Click += new System.EventHandler(this.ContextMenuPaste_Click);
            // 
            // contextMenuDelete
            // 
            this.contextMenuDelete.Name = "contextMenuDelete";
            this.contextMenuDelete.Size = new System.Drawing.Size(155, 32);
            this.contextMenuDelete.Text = "Delete";
            this.contextMenuDelete.Click += new System.EventHandler(this.ContextMenuRemove_Click);
            // 
            // contextMenuSelectAll
            // 
            this.contextMenuSelectAll.Name = "contextMenuSelectAll";
            this.contextMenuSelectAll.Size = new System.Drawing.Size(155, 32);
            this.contextMenuSelectAll.Text = "Select All";
            this.contextMenuSelectAll.Click += new System.EventHandler(this.ContextMenuSelectAll_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSalmon;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ScaleLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 602);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(932, 32);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(60, 25);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // ScaleLabel
            // 
            this.ScaleLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ScaleLabel.Name = "ScaleLabel";
            this.ScaleLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ScaleLabel.Size = new System.Drawing.Size(57, 25);
            this.ScaleLabel.Text = "100%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 634);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topMenuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem topMenuSave;
        private System.Windows.Forms.ToolStripMenuItem topMenuPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem topMenuExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topMenuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topMenuShowInfo;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem contextMenuUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem contextMenuCut;
        private System.Windows.Forms.ToolStripMenuItem contextMenuCopy;
        private System.Windows.Forms.ToolStripMenuItem contextMenuPast;
        private System.Windows.Forms.ToolStripMenuItem contextMenuDelete;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topMenuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem topMenuFont;
        private System.Windows.Forms.ToolStripMenuItem contextMenuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem topMenuUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem topMenuCopy;
        private System.Windows.Forms.ToolStripMenuItem topMenuCut;
        private System.Windows.Forms.ToolStripMenuItem topMenuPast;
        private System.Windows.Forms.ToolStripMenuItem topMenuDelete;
        private System.Windows.Forms.ToolStripMenuItem topMenuTextColor;
        private System.Windows.Forms.ToolStripMenuItem topMenuBackColor;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scaleIncrease;
        private System.Windows.Forms.ToolStripMenuItem scaleDecrease;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ScaleLabel;
    }
}

