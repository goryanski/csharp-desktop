using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShipsPractice.Models;

namespace ShipsPractice
{
    public partial class Form1 : Form
    {
        List<WorkShip> allShips = new List<WorkShip>();
        List<WorkShip> shipsInTunnel = new List<WorkShip>();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            InitStocks();
            InitShips();
        }
        private void InitShips()
        {
            for (int i = 0; i < 7; i++)
            {
                WorkShip breadShip = new WorkShip { Product = "Bread", Сapacity = 10 };
                Subscribe(breadShip);
                allShips.Add(breadShip);
                breadShip.Start();

                WorkShip bananasShip = new WorkShip { Product = "Banana", Сapacity = 50 };
                Subscribe(bananasShip);
                allShips.Add(bananasShip);
                bananasShip.Start();

                WorkShip clothesShip = new WorkShip { Product = "Cloth", Сapacity = 100 };
                Subscribe(clothesShip);
                allShips.Add(clothesShip);
                clothesShip.Start();
            }
            UpdateLbAllShips();
        }

        private void Subscribe(WorkShip wt)
        {
            wt.ShipEntersTheTunnel += (t) =>
            {
                int idx = allShips.IndexOf(t);
                shipsInTunnel.Add(t);
                UpdateLbShipsInTunnel();

                allShips.Remove(t);
                UpdateLbAllShips();
            };

            wt.ShipGoesFromTunnel += (t) =>
            {
                int idx = shipsInTunnel.IndexOf(t);

                shipsInTunnel.Remove(t);
                UpdateLbShipsInTunnel();
            };

            wt.ShipBreadGoesToStock += (t) =>
            {
                int counter = 0;
                while (counter < t.Сapacity)
                {
                    lblBreadStock.Text = $"{++counter}";
                }
            };
            wt.ShipBananaGoesToStock += (t) =>
            {
                int counter = 0;
                while (counter < t.Сapacity)
                {
                    lblBananasStock.Text = $"{++counter}";
                }
            };
            wt.ShipClothGoesToStock += (t) =>
            {
                int counter = 0;
                while (counter < t.Сapacity)
                {
                    lblClothesStock.Text = $"{++counter}";
                }
            };
        }

        private void UpdateLbAllShips()
        {
            BeginInvoke(new Action(() =>
            {
                lbAllShips.DataSource = null;
                lbAllShips.DataSource = allShips;
            }));
        }

        private void UpdateLbShipsInTunnel()
        {
            BeginInvoke(new Action(() =>
            {
                lbTunnel.DataSource = null;
                lbTunnel.DataSource = shipsInTunnel;
            }));
        }

        private void InitStocks()
        {
            lblBreadStock.Text = lblBananasStock.Text = lblClothesStock.Text = "0";
        }


    }
}
