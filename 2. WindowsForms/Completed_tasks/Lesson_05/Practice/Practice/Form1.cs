using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    public partial class Form1 : Form
    {
        int R = 0;
        int G = 0;
        int B = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void RgbScroll(object sender, EventArgs e)
        {
            TrackBar trackBar = (sender as TrackBar);
            if (trackBar.Name.Equals("trackBarR"))
            {
                R = trackBar.Value;
            }
            else if (trackBar.Name.Equals("trackBarG"))
            {
                G = trackBar.Value;
            }
            else if (trackBar.Name.Equals("trackBarB"))
            {
                B = trackBar.Value;
            }

            this.BackColor = Color.FromArgb(R, G, B);
        }
    }
}
