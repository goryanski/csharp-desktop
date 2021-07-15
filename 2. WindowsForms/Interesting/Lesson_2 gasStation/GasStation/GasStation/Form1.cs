using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasStation
{
    public partial class BestOil : Form
    {
        Timer timer;
        GasStationManager gas;
        CafeManager cafe;
        public double AllMoney { get; set; }
        public string GeneralGasSum { get; set; }        

        public BestOil()
        {
            InitializeComponent();

            // дял GasStation запишем марки бензина в комбо-бокс
            gas = new GasStationManager();
            comboBoxGas.Items.AddRange(gas.Marks.ToArray());
            
           // для Cafe запишем цены на продукты
           cafe = new CafeManager();
            int count = 0;
            foreach (var control in pricePanel.Controls)
            {
                (control as TextBox).Text = cafe.Prices.Values.ElementAt(count++);
            }


            timer = new Timer { Interval = 10_000 };
            timer.Tick += Timer_Tick;
        }      

        #region Заправка
        private void ComboBoxGas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selItem = comboBoxGas.SelectedItem.ToString();
            tbGasPrice.Text = gas.Prices[selItem];

            // разрешим использовать радио баттоны только после того как выберем бензин
            rbGasCount.Enabled = true;
            rbGasSum.Enabled = true;

            // если после изменения суммы или кол-ва бензина пользователь вдруг захочет изменить марку бензина - пересчитаем сумму, выводимую на экран
            if (!tbGasCount.ReadOnly)
            {
                GeneralSumByCount();
            }
            if (!tbGasSum.ReadOnly)
            {
                GeneralSumByMoney();
            }
        }

        private void RbGasCount_Click(object sender, EventArgs e)
        {
            tbGasSum.Text = "";          
            tbGasSum.ReadOnly = true;
            tbGasCount.ReadOnly = false;
        }

        private void RbGasSum_Click(object sender, EventArgs e)
        {
            tbGasCount.Text = "";           
            tbGasCount.ReadOnly = true;
            tbGasSum.ReadOnly = false;
        }

        private void TbGasCount_TextChanged(object sender, EventArgs e)
        {
            GeneralSumByCount();
        }

        private void TbGasSum_TextChanged(object sender, EventArgs e)
        {
            GeneralSumByMoney();
        }

        private void tbGasSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar == ',' && tbGasSum.Text.Contains(",")) ||
                e.KeyChar == '.') // что бы не вводили . вместо ,
            {
                e.Handled = true;
            }
        }

        void GeneralSumByCount()
        {
            // если мы не ввели кол-во бензина или стерли строку, то сумму к оплате отображать не будем
            if (tbGasCount.Text == "")
            {
                lblGeneralGasSum.Text = "";
            }
            else
            {
                gbGasGeneralSum.Text = "К оплате"; // gb = GroupBox
                lblSumCurrency.Text = "грн.";
                if (gas.CheckGasCount(tbGasCount.Text))
                {
                    // покажем общую сумму 
                    lblGeneralGasSum.Text = gas.CalcSumByCount(tbGasCount.Text, tbGasPrice.Text);
                    // запишем общую сумму
                    GeneralGasSum = lblGeneralGasSum.Text;
                }
                else
                {
                    lblGeneralGasSum.Text = "Неверный ввод";
                }
            }
        }

        void GeneralSumByMoney()
        {
            if (tbGasSum.Text == "")
            {
                lblGeneralGasSum.Text = "";
            }
            else
            {
                gbGasGeneralSum.Text = "К выдаче";
                lblSumCurrency.Text = "л.";
                if (gas.CheckGasSum(tbGasSum.Text))
                {
                    if (double.Parse(tbGasSum.Text) >= double.Parse(tbGasPrice.Text))
                    {
                        // покажем общую сумму 
                        lblGeneralGasSum.Text = gas.CalcSumByMoney(tbGasSum.Text, tbGasPrice.Text);
                        // запишем общую сумму но уже не с экрана
                        GeneralGasSum = tbGasSum.Text;
                    }
                    else
                    {
                        lblGeneralGasSum.Text = "Мало денег";
                    }
                }
                else
                {
                    lblGeneralGasSum.Text = "Неверный ввод";
                }
            }
        }
        #endregion

        #region Кафе
        private void Food_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            TextBox foodCount = GetTextBoxFoodCount(checkBox.Name);

            if (checkBox.Checked)
            {
                foodCount.ReadOnly = false;
                if (foodCount.Text == "")
                {
                    SetErrorLabelText(foodCount.Name, "X");
                }
            }
            else
            {
                foodCount.ReadOnly = true;
                foodCount.Text = "";
                SetErrorLabelText(foodCount.Name, "");
            }
            CalculateGeneralSum();
        }


        private void FoodCount_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (cafe.IsFoodCountValid(textBox.Text))
            {
                SetErrorLabelText(textBox.Name, "");
                CalculateGeneralSum();
            }
            else
            {
                generalSumCafe.Text = "";
                SetErrorLabelText(textBox.Name, "X");
            }
        }

        void CalculateGeneralSum()
        {
            double tmp = 0;
            if (hotDogCount.ReadOnly == false && hotDogCount.Text != "")
            {
                tmp += (double.Parse(hotDogCount.Text) * double.Parse(hotDogPrice.Text));
            }
            if (hamburgerCount.ReadOnly == false && hamburgerCount.Text != "")
            {
                tmp += (double.Parse(hamburgerCount.Text) * double.Parse(hamburgerPrice.Text));
            }
            if (friesCount.ReadOnly == false && friesCount.Text != "")
            {
                tmp += (double.Parse(friesCount.Text) * double.Parse(friesPrice.Text));
            }
            if (colaCount.ReadOnly == false && colaCount.Text != "")
            {
                tmp += (double.Parse(colaCount.Text) * double.Parse(colaPrice.Text));
            }

            generalSumCafe.Text = tmp.ToString();
        }

        TextBox GetTextBoxFoodCount(string checkBoxName)
        {
            switch (checkBoxName)
            {
                case "cbHotDog":
                    return hotDogCount;

                case "cbHamburger":
                    return hamburgerCount;

                case "cbFries":
                    return friesCount;

                case "cbCola":
                    return colaCount;
            }
            return null;
        }
        void SetErrorLabelText(string name, string value)
        {
            switch (name)
            {
                case "hotDogCount":
                    hotDogCorrect.Text = value;
                    break;
                case "hamburgerCount":
                    hamburgerCorrect.Text = value;
                    break;
                case "friesCount":
                    friesCorrect.Text = value;
                    break;
                case "colaCount":
                    colaCorrect.Text = value;
                    break;
            }
        }





        #endregion

        #region Завершение
        private void CalcButton_Click(object sender, EventArgs e)
        {
            // проверки, что бы нельзя было посчитать неверно введенные данные
            if ((lblGeneralGasSum.Text != "" && lblGeneralGasSum.Text != "Мало денег" &&
                lblGeneralGasSum.Text != "Неверный ввод") || (generalSumCafe.Text != "0" && generalSumCafe.Text != ""))
            {

                // на случай если решим заказать только один бензин или только продукты
                double sumCafe = 0;
                if(generalSumCafe.Text != "")
                {
                    sumCafe = double.Parse(generalSumCafe.Text);
                }
                double sumGas = 0;
                if (GeneralGasSum != "")
                {
                    sumGas = double.Parse(GeneralGasSum);
                }

                commonSum.Text = (sumGas + sumCafe).ToString();
                timer.Start();
            }    
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // что бы новое всплывающее окно не появлялось, пока не закроем это
            timer.Enabled = false;

            var result = MessageBox.Show("Очистить форму?", "Завершение работы с клиентом", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    timer.Stop();
                    AllMoney += double.Parse(commonSum.Text);
                    ClearForm();                   
                    break;
                case DialogResult.No:
                    // если нет - продолжим работу таймера
                    timer.Enabled = true;
                    break;
            }
        }
        void ClearForm()
        {
            // очистим и снова добавим элементы в  comboBox что бы спрятать их
            comboBoxGas.Items.Clear();
            comboBoxGas.Items.AddRange(gas.Marks.ToArray());

            // TextBoxs
            foreach (var control in GasStationPanel.Controls)
            {
                if(control is TextBox)
                {
                    (control as TextBox).Text = "";
                    (control as TextBox).ReadOnly = true;
                }
            }

            // CheckBoxs
            foreach (var control in foodPanel.Controls)
            {
                (control as CheckBox).Checked = false;
            }

            // labels
            generalSumCafe.Text = "";
            commonSum.Text = "";

            GeneralGasSum = "";
            rbGasCount.Enabled = false;
            rbGasSum.Enabled = false;
        }

        private void BestOil_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show($"{AllMoney} грн.", "Дневная выручка");
        }
        #endregion
    }
}
