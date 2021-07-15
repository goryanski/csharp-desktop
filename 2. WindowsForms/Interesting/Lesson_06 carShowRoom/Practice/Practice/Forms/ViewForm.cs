using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practice.Models;

namespace Practice
{
    public partial class ViewForm : System.Windows.Forms.Form
    {
        public ViewForm(Car car)
        {
            InitializeComponent();
            LoadCarToForm(car);
        }

        private void LoadCarToForm(Car car)
        {
            Text = $"{car.Mark} {car.Model}";
            lblCarDescription.Text = car.ShowDetailedInfo();
            pbCarImage.Image = Image.FromFile(car.PicturePath);

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
