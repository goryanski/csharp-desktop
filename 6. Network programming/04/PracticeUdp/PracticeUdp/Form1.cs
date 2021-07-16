using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpdChatLibrary.Helpers;
using UpdChatLibrary.Models;

namespace PracticeUdp
{
    public partial class Form1 : Form
    {

        FileHelper fileHelper = new FileHelper();
        ChatUdpClient client;
        Member currentMember = new Member();
        string messageFilePath;
        UdpClient udpClient = new UdpClient();
        bool fileMessageHasBeenSeen = false;
        string newFilePath;

        public Form1()
        {
            InitializeComponent();
            ClientInit();
            this.Load += Form_Load;
            this.FormClosed += Form_FormClosed;
            fileHelper.CreateListOfMembersFile(new List<Member>());
        }

        #region Load
        private void ClientInit()
        {
            Random random = new Random();
            int randomPort = random.Next(55_001, 65_000);
            client = new ChatUdpClient("127.0.0.1", randomPort);
            currentMember.Port = randomPort;
            client.RecieveTextMessageEvent += Client_RecieveTextMessageEvent;
            client.RecieveFullMessageEvent += Client_RecieveFullMessageEvent;
            client.Start();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            rtbMessage.Enabled = false;
            rtbScreen.ReadOnly = true;
            chBoxFileExists.Enabled = false;
            btnChooseFile.Enabled = false;
            cbMembers.Enabled = false;
        }
        #endregion

        #region Registration
        private void BtnConfirmNick_Click(object sender, EventArgs e)
        {
            if (tbNickName.Text != string.Empty)
            {
                // NickName change taboo
                tbNickName.Enabled = false;
                btnConfirmNick.Enabled = false;
                // unblock elements to send messages
                rtbMessage.Enabled = true;
                btnChooseFile.Enabled = true;
                cbMembers.Enabled = true;


                currentMember.NickName = tbNickName.Text;
                AddToListOfMembers(currentMember);
            }
        }

        private void AddToListOfMembers(Member member)
        {
            var members = fileHelper.GetListOfMembersFile();
            members.Add(member);
            fileHelper.DeleteListOfMembersFile();
            fileHelper.CreateListOfMembersFile(members);
        }
        #endregion

        #region Send
        private void BtnChooseFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();

                DialogResult result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    messageFilePath = dlg.FileName;
                    chBoxFileExists.Checked = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (cbMembers.SelectedIndex != -1)
            {
                if (chBoxFileExists.Checked == true || rtbMessage.Text != string.Empty)
                {
                    UdpMessage msg = new UdpMessage();
                    if (chBoxFileExists.Checked == true)
                    {
                        msg.Type = MessageType.WithFile;
                        msg.FileExtention = Path.GetExtension(messageFilePath);
                        msg.FilePath = messageFilePath;
                    }
                    else
                    {
                        msg.Type = MessageType.OnlyText;
                    }
                    msg.Member = currentMember;
                    msg.DestinationPort = (cbMembers.SelectedItem as Member).Port;
                    msg.Text = rtbMessage.Text;

                    client.SendMessage(msg, udpClient);
                    rtbMessage.Text = string.Empty;
                    chBoxFileExists.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("You must first select a member");
            }
        }

        private void CbMembers_Click(object sender, EventArgs e)
        {
            var members = fileHelper.GetListOfMembersFile();
            cbMembers.DataSource = null;
            cbMembers.DataSource = members;
        }
        #endregion

        #region RecieveMsg
        private void Client_RecieveFullMessageEvent(UdpMessage msg)
        {          
            BeginInvoke(new Action(() =>
            {
                string ownSavedMessage = string.Empty;
                if (msg.Member.Port == currentMember.Port)
                {
                    ownSavedMessage = " (Your own saved message)";
                }
                rtbScreen.Text += $"{msg.Member.NickName}{ownSavedMessage}: {msg.Text} (You've got a new file)\n";
                newFilePath = msg.FilePath;
                ShowFile();
            }));
        }

        private void Client_RecieveTextMessageEvent(UdpMessage msg)
        {
            BeginInvoke(new Action(() =>
            {
                string ownSavedMessage = string.Empty;
                if(msg.Member.Port == currentMember.Port)
                {
                    ownSavedMessage = " (Your own saved message)";
                }
                rtbScreen.Text += $"{msg.Member.NickName}{ownSavedMessage}: {msg.Text}\n";
            }));
        }

        private void ShowFile()
        {
            btnFile.Text = "New File";

            Task.Run(() =>
            {
                while (!fileMessageHasBeenSeen)
                {
                    btnFile.BackColor = Color.Orange;
                    Thread.Sleep(100);
                    btnFile.BackColor = Color.White;
                    Thread.Sleep(100);
                }
            });
        }

        private void BtnFile_Click(object sender, EventArgs e)
        {
            if (btnFile.Text == "New File")
            {
                btnFile.Text = string.Empty;
                fileMessageHasBeenSeen = true;
                Process.Start(newFilePath);
                fileMessageHasBeenSeen = false;
            }
        }
        #endregion

        #region FormClosed
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            DeleteMember();
        }

        private void DeleteMember()
        {
            var members = fileHelper.GetListOfMembersFile();
            if (members.Count > 0)
            {
                members.Remove(members.First(m => m.Port == currentMember.Port));
                fileHelper.DeleteListOfMembersFile();
                fileHelper.CreateListOfMembersFile(members);
            }          
        }
        #endregion
    }
}
