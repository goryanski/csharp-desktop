using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exam.Models;

namespace Exam.forms
{
    public partial class ViewPhotoForm : Form
    {
        Photo photo;
        public ViewPhotoForm(Photo photo)
        {
            InitializeComponent();
            this.photo = new Photo();
            this.photo = photo;
            LoadPhotoToForm(this.photo);
        }

        private void LoadPhotoToForm(Photo photo)
        {
            Text = $"{photo.PhotoName}";
            lblFotoFullInfo.Text = photo.ShowDetailedInfo();
            pbPhoto.Image = Image.FromFile(photo.PhotoPath);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show(photo.PhotoDescription, "Description", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
