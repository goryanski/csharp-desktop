using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmtpPractice.Helpers;

namespace SmtpPractice
{
    public partial class Form1 : Form
    {
        string[] selectedFiles = null;
        SendService sendService = new SendService();
        public Form1()
        {
            InitializeComponent();
            lblSendInfo.Visible = false;
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if(tbDestination.Text != string.Empty && rbxMessageText.Text != string.Empty)
            {
                btnSend.Enabled = false;

                try
                {
                    Send();

                    selectedFiles = null;
                    rbxMessageText.Text = string.Empty;
                    lblSendInfo.Visible = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }

                btnSend.Enabled = true;
            }
            else
            {
                MessageBox.Show("Mail address and message text can't be empty");
            }
        }

        private async Task Send()
        {
            await sendService.SendMailMessage (
                    tbDestination.Text
                    , tblTheme.Text
                    , rbxMessageText.Text
                    , false
                    , sendService.GetAttachments(selectedFiles)
             );
        }

        private void BtnChooseFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog() 
                { 
                    Multiselect = true 
                };

                DialogResult result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedFiles = dlg.FileNames;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void RbxMessageText_TextChanged(object sender, EventArgs e)
        {
            lblSendInfo.Visible = false;
        }
    }
}
