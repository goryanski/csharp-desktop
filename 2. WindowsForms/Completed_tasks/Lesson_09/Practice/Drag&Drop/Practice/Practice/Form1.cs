using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    public partial class Form1 : Form
    {
        string openedFilePath;
        bool fileWasOpened;
        int scalePercent;
        public Form1()
        {
            InitializeComponent();
            richTextBox.ContextMenuStrip = contextMenu;
            fileWasOpened = false;

            richTextBox.AllowDrop = true;
            richTextBox.DragEnter += RichBox_DragEnter;
            richTextBox.DragDrop += RichBox_DragDrop;
        }

        private void RichBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = e.Data.GetData(DataFormats.FileDrop) as string[];
            richTextBox.Text = File.ReadAllText(paths[0]);
        }

        private void RichBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        #region Top Menu

        #region Menu item File
        private void TopMenuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Text files(*.rtf)|*.rtf"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox.LoadFile(dlg.FileName);
                openedFilePath = dlg.FileName;
                fileWasOpened = true;
            }
        }

        private void TopMenuSave_Click(object sender, EventArgs e)
        {
            if(fileWasOpened)
            {
                richTextBox.SaveFile(openedFilePath, RichTextBoxStreamType.RichText);
            }
            else
            {
                SaveToSelectedFile();
            }
        }

        private void TopMenuSaveAs_Click(object sender, EventArgs e)
        {
            SaveToSelectedFile();
        }

        private void SaveToSelectedFile()
        {
            SaveFileDialog dlg = new SaveFileDialog()
            {
                Filter = "Text files(*.rtf)|*.rtf"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SaveFile(dlg.FileName, RichTextBoxStreamType.RichText);
            }
        }

        private void TopMenuPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Print");
        }

        private void TopMenuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Menu item Format
        private void TopMenuFont_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog
            {
                Font = richTextBox.SelectionFont,
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionFont = dlg.Font;
            }
        }
        private void TopMenuTextColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog
            {
                AnyColor = true,
                AllowFullOpen = true,
                Color = richTextBox.SelectionColor
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionColor = dlg.Color;
            }
        }

        private void TopMenuBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog
            {
                AnyColor = true,
                AllowFullOpen = true,
                Color = richTextBox.SelectionBackColor
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionBackColor = dlg.Color;
            }
        }

        #endregion

        private void ScaleIncrease_Click(object sender, EventArgs e)
        {
            if (richTextBox.ZoomFactor < 15)
            {
                richTextBox.ZoomFactor += 1;
                int percent = 100 + (Convert.ToInt32(richTextBox.ZoomFactor) * 10);
                scalePercent = percent;
                ScaleLabel.Text = percent.ToString() + "%";
            }
        }
        private void ScaleDecrease_Click(object sender, EventArgs e)
        {
            if (richTextBox.ZoomFactor > 1)
            {
                richTextBox.ZoomFactor -= 1;               
                scalePercent -= 10;
                if(richTextBox.ZoomFactor == 1)
                {
                    scalePercent = 100;
                }
                ScaleLabel.Text = scalePercent.ToString() + "%";
            }
        }
        private void TopMenuShowInfo_Click(object sender, EventArgs e)
        {
           MessageBox.Show("© ООО «Рога и копыта», 2000-2015\nВсе права защищены");
        }
        #endregion



        #region Context Menu
        private void ContextMenuPaste_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }

        private void ContextMenuCopy_Click(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }

        private void ContextMenuCut_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void ContextMenuUndo_Click(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        private void ContextMenuRemove_Click(object sender, EventArgs e)
        {
            richTextBox.SelectedText = "";
        }

        private void ContextMenuSelectAll_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();
        }






        #endregion
    }
}
