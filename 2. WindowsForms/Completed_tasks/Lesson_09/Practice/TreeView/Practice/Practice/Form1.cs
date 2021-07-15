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
        public Form1()
        {
            InitializeComponent();
            TreeViewInit();
        }

        private void TreeViewInit()
        {
            string[] drives = Environment.GetLogicalDrives();
            LoadNodes(drives);
            treeView.BeforeExpand += TreeView_BeforeExpand;
            treeView.AfterExpand += TreeView_AfterExpand;
            treeView.AfterCollapse += TreeView_AfterCollapse;
            treeView.AfterSelect += TreeView_AfterSelect;

            var imgList = new ImageList();
            imgList.Images.AddRange(new Image[]
            {
                Image.FromFile("close-folder.png"),
                Image.FromFile("open-folder.png"),
                Image.FromFile("file.png"),
            });
            treeView.ImageList = imgList;
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // загрузим файл в пикчербокс если выбранный файл является картинкой
            ShowIfPicture(e);        
        }

        private void TreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (Directory.Exists(e.Node.FullPath))
            {
                e.Node.ImageIndex = 0;
                e.Node.SelectedImageIndex = 0;
            }
        }

        private void TreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (Directory.Exists(e.Node.FullPath))
            {
                e.Node.ImageIndex = 1;
                e.Node.SelectedImageIndex = 1;
            }         
        }

        private void TreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(e.Node.FullPath);
                string[] files = Directory.GetFiles(e.Node.FullPath);

                // из всех файлов отберем только картинки
                List<string> images = new List<string>();
                string extension;
                foreach (var file in files)
                {
                    extension = Path.GetExtension(file);
                    if (isPicture(extension))
                    {
                        images.Add(file);
                    }
                }
                
                if (dirs.Length == 0 && files.Length == 0)
                {
                    e.Node.Nodes.Clear();
                }
                else
                {
                    e.Node.Nodes.Clear();
                    LoadNodes(dirs, e.Node);

                    // и загрузим только картинки
                    LoadNodes(images.ToArray(), e.Node);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                // исключение происходит, если кликаем дважды на файл в дереве, который не является папкой, но если это картинка, то при двойном клике так же покажем ее в пикчербокс
                if (!ShowIfPicture(e))
                {
                    e.Node.Nodes.Clear();
                    MessageBox.Show(ex.Message);
                }          
            }
        }

        private void LoadNodes(string[] items, TreeNode node = null)
        {
            foreach (var item in items)
            {
                var isDir = File.Exists(item) ? false : true;
                var imageIndex = isDir ? 0 : 2;
                TreeNode newNode = new TreeNode(item, imageIndex, imageIndex);
                newNode.Nodes.Add("");
                if (node is null)
                {
                    treeView.Nodes.Add(newNode);
                }
                else
                {
                    newNode.Text = Path.GetFileName(item);
                    newNode.Tag = item;

                    node.Nodes.Add(newNode);
                }
            }
        }

        private void ShowIfPicture(TreeViewEventArgs e)
        {
            string extension = Path.GetExtension(e.Node.FullPath);

            if (isPicture(extension))
            {
                pictureBox.Image = Image.FromFile(e.Node.FullPath);
            }
        }
        private bool ShowIfPicture(TreeViewCancelEventArgs e)
        {
            string extension = Path.GetExtension(e.Node.FullPath);

            if (isPicture(extension))
            {
                pictureBox.Image = Image.FromFile(e.Node.FullPath);
                return true;
            }
            return false;
        }
        private bool isPicture(string extension)
        {
            if (extension.Equals(".jpeg") ||
                extension.Equals(".jpg") ||
                extension.Equals(".png"))
            {
                return true;
            }
            return false;
        }
    }
}
