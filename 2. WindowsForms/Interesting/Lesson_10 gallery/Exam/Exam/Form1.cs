using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exam.forms;
using Exam.Models;
using Exam.Models.Helpers;

/*
    user login: igor 
    user password: 1111 
 */

namespace Exam
{
    public partial class Form1 : Form
    {
        const string EMPTY_STRING = "";
        PhotosStorage photosStorage = PhotosStorage.Instance; 
        bool userLoggedIn = false;
        string authenticatedUserLogin = EMPTY_STRING;
        string defaultSearchText;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;         
        }

        #region Form Load
        private void Form_Load(object sender, EventArgs e)
        {
            SetDefaultTitle();
            defaultSearchText = "find photo by name or category...";
            SetDefaultSearchText();
            BlockButtons();
            LoadPhotosListToForm();
            lblNotFound.Visible = false;
            LoadCategoiesList();
        }

        private void SetDefaultTitle()
        {
            Text = "Hello, guest! Log in and use Photo Gallery Pro";
        }

        private void SetDefaultSearchText()
        {
            tbSearch.Text = defaultSearchText;
            tbSearch.ForeColor = Color.Gray;
        }
        
        private void BlockButtons()
        {
            btnAddPhoto.Enabled = false;
            btnEditPhoto.Enabled = false;
            btnDeletePhoto.Enabled = false;
            btnShowPhoto.Enabled = false;
        }

        private void LoadPhotosListToForm()
        {
            lbChoosePhoto.DataSource = photosStorage.Photos;
        }

        private void LoadCategoiesList()
        {
            var CategoiesList = photosStorage.Photos.Select(
                ph => ph.PhotoCategory
                );

            cbCategoiesList.DataSource = CategoiesList.Distinct().ToList();
        }
        #endregion

        #region  Authentication
        private void BtnRegistration_Click(object sender, EventArgs e)
        {
            AuthenticationForm form = new AuthenticationForm(AuthenticationForm.Action.Registration)
            {
                StartPosition = FormStartPosition.CenterParent,
                Owner = this
            };

            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Registration complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (!userLoggedIn)
            {
                AuthenticationForm form = new AuthenticationForm(AuthenticationForm.Action.Login)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Owner = this
                };

                if (form.ShowDialog() == DialogResult.OK)
                {
                    UserLoginSettings(form.Person.Login);
                }
            }
            else
            {
                UserLogOutSettings();
            }
        }

        private void UserLoginSettings(string login)
        {
            userLoggedIn = true;
            Text = $"Hello, {login}!";
            UnblockButtons();
            btnLogin.Text = "Log out";
            btnRegistration.Visible = false;
            authenticatedUserLogin = login;
        }

        private void UserLogOutSettings()
        {
            userLoggedIn = false;
            SetDefaultTitle();
            BlockButtons();
            btnLogin.Text = "Log in";
            btnRegistration.Visible = true;
            authenticatedUserLogin = "";
        }

        private void UnblockButtons()
        {
            btnAddPhoto.Enabled = true;
            btnEditPhoto.Enabled = true;
            btnDeletePhoto.Enabled = true;
            btnShowPhoto.Enabled = true;
        }
        
        #endregion

        #region Action buttons for photos management 
        private void BtnAddPhoto_Click(object sender, EventArgs e)
        {
            EditForm form = new EditForm(EditForm.Action.Add)
            {
                StartPosition = FormStartPosition.CenterParent,
                Owner = this
            };

            if (form.ShowDialog() == DialogResult.OK)
            {
                form.Picture.PhotoAuthor = authenticatedUserLogin;
                form.Picture.DownloadDataTime = DateTime.Now;
                photosStorage.Photos.Add(form.Picture);
                ReloadPhotosList();
                // для автоматического обновления фильтра по категориям
                LoadCategoiesList();
            }
        }

        private void BtnEditPhoto_Click(object sender, EventArgs e)
        {
            if (lbChoosePhoto.SelectedIndex != -1)
            {
                Photo selectedPhoto = lbChoosePhoto.SelectedItem as Photo;
                if (authenticatedUserLogin.Equals(selectedPhoto.PhotoAuthor))
                {
                    EditForm form = new EditForm(EditForm.Action.Edit, selectedPhoto.Clone() as Photo)
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        Owner = this
                    };

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        selectedPhoto.Copy(form.Picture);
                        ReloadPhotosList();
                        LoadCategoiesList();
                    }
                }
                else
                {
                    MessageBox.Show("You can edit only your photos", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }                    
        }

        private void BtnShowPhoto_Click(object sender, EventArgs e)
        {
            RunViewForm();
        }

        private void BtnDeletePhoto_Click(object sender, EventArgs e)
        {
            if (lbChoosePhoto.SelectedIndex != -1)
            {
                Photo selectedPhoto = lbChoosePhoto.SelectedItem as Photo;
                if (authenticatedUserLogin.Equals(selectedPhoto.PhotoAuthor))
                {
                    photosStorage.Photos.Remove(selectedPhoto);
                    ReloadPhotosList();
                    LoadCategoiesList();
                }
                else
                {
                    MessageBox.Show("You can delete only your photos", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #region Helper methods
        private void RunViewForm()
        {
            if (lbChoosePhoto.SelectedIndex != -1)
            {
                Photo selectedPhoto = lbChoosePhoto.SelectedItem as Photo;

                ViewPhotoForm viewPhotoForm = new ViewPhotoForm(selectedPhoto)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    Owner = this
                };
                viewPhotoForm.ShowDialog();
            }
        }

        private void ReloadPhotosList()
        {
            lbChoosePhoto.DataSource = null;
            lbChoosePhoto.DataSource = photosStorage.Photos;
        }
        #endregion       

        #endregion

        #region Search and filter for photos

        #region Search
        private void TbSearch_Enter(object sender, EventArgs e)
        {
            if (tbSearch.Text.Equals(defaultSearchText))
            {
                tbSearch.Text = EMPTY_STRING;
            }
        }

        private void TbSearch_Leave(object sender, EventArgs e)
        {
            if (tbSearch.Text.Equals(EMPTY_STRING))
            {
                SetDefaultSearchText();
            }
        }   

        // живой поиск
        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            if (tbSearch.Text.Equals(EMPTY_STRING) ||
                tbSearch.Text.Equals(defaultSearchText))
            {
                ReloadPhotosList();
                lblNotFound.Visible = false;
            }
            else
            {
                lbChoosePhoto.DataSource = null;
                lblNotFound.Visible = false;

                List<Photo> srchPhotos = photosStorage.Photos.Where(
                ph =>
                ph.PhotoName.ToUpper().Contains(tbSearch.Text.ToUpper()) ||
                ph.PhotoCategory.ToUpper().Contains(tbSearch.Text.ToUpper())
                ).ToList();

                if (srchPhotos.Count > 0)
                {
                    lbChoosePhoto.DataSource = srchPhotos;
                }
                else
                {
                    lblNotFound.Visible = true;
                }
            }
        }
        #endregion

        #region filters
        private void BtnFilterByCategory_Click(object sender, EventArgs e)
        {
            string selectedCategory = cbCategoiesList.SelectedItem as string;

            var SelectedPhotos = photosStorage.Photos.Where(
                ph => ph.PhotoCategory.Equals(selectedCategory)
                ).ToList();

            lbChoosePhoto.DataSource = SelectedPhotos;
        }

        private void BtnFilterByDate_Click(object sender, EventArgs e)
        {
            // изменим полученное время, что бы корректно фильтровались фото, поскольку автоматически считывается текушее время, и в разное время суток будут разные результаты поиска
            var dateFrom = dtpFrom.Value;
            TimeSpan timeFrom = new TimeSpan(00, 00, 00);
            dateFrom = dateFrom.Date + timeFrom;

            var dateTo = dtpTo.Value;
            TimeSpan timeTo = new TimeSpan(23, 59, 59);
            dateTo = dateTo.Date + timeTo;

            var SelectedPhotos = photosStorage.Photos.Where(
                ph => 
                ph.DownloadDataTime >= dateFrom &&
                ph.DownloadDataTime <= dateTo
                ).ToList();

            if(SelectedPhotos.Count > 0)
            {
                lbChoosePhoto.DataSource = null;
                lbChoosePhoto.DataSource = SelectedPhotos;
                lblNotFound.Visible = false;
            }
            else
            {
                lbChoosePhoto.DataSource = null;
                lblNotFound.Visible = true;
            }
        }
       
        private void BtnFilterByDate_Leave(object sender, EventArgs e)
        {
            lblNotFound.Visible = false;
        }
        #endregion

        private void BtnClearFilters_Click(object sender, EventArgs e)
        {
            ReloadPhotosList();
            SetDefaultSearchText();
        }
        #endregion

        private void LbChoosePhoto_DoubleClick(object sender, EventArgs e)
        {
            if (userLoggedIn)
            {
                RunViewForm();
            }
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            photosStorage.SaveToFile();
        }
    }
}
