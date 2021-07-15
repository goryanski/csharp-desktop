using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exam.Models;
using Exam.Models.Helpers;

namespace Exam.forms
{
    public partial class EditForm : Form
    {
        public enum Action
        {
            Edit,
            Add
        }

        public Photo Picture { get; set; }
        string defaultImagePath;
        PhotoValidator validator = new PhotoValidator();

        public EditForm(Action action, Photo photo = null)
        {
            InitializeComponent();
            InitializeFields(photo);          
            RunAction(action);
        }

        #region Load Form
        private void InitializeFields(Photo photo)
        {
            if (photo is null)
            {
                Picture = new Photo();
            }
            else
            {
                Picture = photo;
            }
            defaultImagePath = Path.Combine(ImageSaveHelper.UPLOAD, "no_image.png");
        }

        private void RunAction(Action action)
        {
            switch (action)
            {
                case Action.Edit:
                    ActionsForEdit();
                    break;
                case Action.Add:
                    ActionsForAdd();
                    break;
            }
        }

        private void ActionsForEdit()
        {
            LoadEditPhotoToForm();
            pbImage.Tag = Picture.PhotoPath;
            Text = "Form of redaction photo";
        }

        private void ActionsForAdd()
        {
            SetDefaultImage();
            pbImage.Tag = defaultImagePath;
            Text = "Form of addition photo";
        }

        private void LoadEditPhotoToForm()
        {
            tbImageName.Text = Picture.PhotoName;
            tbImageCategory.Text = Picture.PhotoCategory;
            tbDescription.Text = Picture.PhotoDescription;
            tbImagePath.Text = Picture.PhotoPath;
            pbImage.Image = Image.FromFile(Picture.PhotoPath);
        }

        private void SetDefaultImage()
        {
            pbImage.Image = Image.FromFile(defaultImagePath);
        }
        #endregion

        #region Buttons click
        private void BtnClearPathField_Click(object sender, EventArgs e)
        {
            tbImagePath.Text = "";
        }

        private void BtnAddImage_Click(object sender, EventArgs e)
        {
            if (tbImagePath.Text != "")
            {
                WebClient wc = new WebClient();
                string filename = Path.GetFileName(tbImagePath.Text);
                string extension = Path.GetExtension(filename);
                filename = $"{Guid.NewGuid().ToString()}{extension}";

                string savePath = Path.Combine(ImageSaveHelper.UPLOAD, filename);

                try
                {
                    wc.DownloadFile(tbImagePath.Text, savePath);
                    pbImage.Image = Image.FromFile(savePath);
                    pbImage.Tag = savePath;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Wrong path. Check entered path.\nMore details:\n" + ex.Message);
                }
                catch (WebException ex)
                {
                    MessageBox.Show("Wrong path. Check entered path.\nMore details:\n" + ex.Message);
                }
            }
        }

        private void BtnOpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Images(.png,.jpg,.jpeg)|*.png;*.jpg;*.jpeg"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string newPath = ImageSaveHelper.Save(dlg.FileName);
                pbImage.Image = Image.FromFile(newPath);
                pbImage.Tag = newPath;
                tbImagePath.Text = newPath;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // теперь не важно, редактируем или добавляем, у нас будет одинаковый набор действий в любом случае
            Picture.PhotoName = tbImageName.Text;
            Picture.PhotoCategory = tbImageCategory.Text;
            Picture.PhotoDescription = tbDescription.Text;
            Picture.PhotoPath = pbImage.Tag.ToString();

            if (validator.IsPhotoValid(Picture))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        #endregion

        private void CbNoPicture_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNoPicture.Checked)
            {
                SetDefaultImage();
                tbImagePath.Text = "";
                tbImagePath.Enabled = false;
                btnAddImage.Enabled = false;
                btnOpenImage.Enabled = false;
                pbImage.Tag = defaultImagePath;
            }
            else
            {
                tbImagePath.Enabled = true;
                btnAddImage.Enabled = true;
                btnOpenImage.Enabled = true;
            }
        }
    }
}
