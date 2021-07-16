using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PracticeEditor.DataBase.Entities;
using PracticeEditor.DataBase.Repository;
using PracticeEditor.Helpers;

namespace PracticeEditor
{
    public partial class Form1 : Form
    {
        public List<User> Users { get; set; }
        IRepositoryAsync<User> usersRepos = new UsersRepository();
        int selectedUserId;
        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            Load += Form_Load;
        }
        private void Form_Load(object sender, EventArgs e)
        {
            editPanel.Visible = false;

            Task.Run(async () =>
            {              
                Users = await usersRepos.GetAll();
                
                BeginInvoke(new Action(() => 
                { 
                    lbUsers.DataSource = Users;
                    lbWait.Visible = false;
                }));
            });       
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (lbUsers.SelectedIndex != -1)
            {
                editPanel.Visible = true;
                User selectedLbItem = lbUsers.SelectedItem as User;
                lbWait.Visible = true;

                Task.Run(async () =>
                {
                    var selectedUser = await usersRepos.Get(selectedLbItem.Id);

                    BeginInvoke(new Action(() =>
                    {
                        selectedUserId = selectedUser.Id;
                        tbFullName.Text = selectedUser.FullName;
                        tbAge.Text = selectedUser.Age.ToString();
                        lbWait.Visible = false;
                    }));
                });
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if(new Validator().IsUserValid(tbFullName.Text, tbAge.Text))
            {
                User user = new User
                {
                    FullName = tbFullName.Text,
                    Age = int.Parse(tbAge.Text),
                    Id = selectedUserId
                };
                lbWait.Visible = true;

                // block during update
                btnEdit.Enabled = false;
                btnSave.Enabled = false;

                Task.Run(async () =>
                {                   
                    await usersRepos.Update(user);

                    BeginInvoke(new Action(() =>
                    {
                        UpdateLbUsers();
                        lbWait.Visible = false;
                        btnEdit.Enabled = true;
                        btnSave.Enabled = true;
                    }));
                });
            }          
        }

        private void UpdateLbUsers()
        {
            lbUsers.DataSource = null;
            lbUsers.DataSource = Users;
        }
    }
}
