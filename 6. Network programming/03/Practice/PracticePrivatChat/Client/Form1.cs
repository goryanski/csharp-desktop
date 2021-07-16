using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatLibrary.Models.Client;
using ChatLibrary.Models;
using System.Threading;
using System.Diagnostics;

namespace Client
{
    public partial class Form1 : Form
    {
        ChatClient client;
        event Action<int> changeMemberCountEvent;
        List<Member> allMembers = new List<Member>();
        int currentClientId;
        string messageFilePath;
        bool fileMessageHasBeenSeen = false;

        public Form1()
        {
            InitializeComponent();           
            ClientInit();
            changeMemberCountEvent += Form_ChangeMembersCountEvent;
            this.Load += Form_Load;
        }

        #region Load
        private void ClientInit()
        {
            client = new ChatClient("127.0.0.1", 55_000);
            clientSubscriptions();
            client.StartListening();
        }

        private void clientSubscriptions()
        {
            client.ConnectFailedEvent += Client_ConnectExceptionEvent;
            client.ReceiveListClientsEvent += Client_ReceiveListClientsEvent;
            client.ReceiveMessageEvent += Client_ReceiveMessageEvent;
            client.SetNewClientIdEvent += Client_SetNewClientIdEvent;
            client.FileSentEvent += Client_FileSentEvent;
            client.WrongFileExeptionEvent += Client_WrongFileExeptionEvent;
        }


        private void Form_Load(object sender, EventArgs e)
        {

            rtbMessage.Enabled = false;
            rtbScreen.ReadOnly = true;
            changeMemberCountEvent?.Invoke(0);
            chBoxFileExists.Enabled = false;
            btnChooseFile.Enabled = false;
        }
        #endregion

        #region Events
        private void Client_WrongFileExeptionEvent(string reason)
        {
            MessageBox.Show(reason);
        }
        private void Client_FileSentEvent()
        {
            chBoxFileExists.Checked = false;
        }
        private void Client_ConnectExceptionEvent(string reason)
        {
            MessageBox.Show(reason);
            BeginInvoke(new Action(() => 
            {
                Close();
            }));          
        }

        private void Client_ReceiveListClientsEvent(List<Member> connectedMembersList)
        {
            // save all members to take nickNames for show them on rtbScreen 
            allMembers = connectedMembersList;

            // get all connected nembers except current member 
            var members = connectedMembersList.Where(m => m.Id != currentClientId).ToList();
            
            // update ListBox
            BeginInvoke(new Action(() =>
            {
                lbMembers.DataSource = null;
                lbMembers.DataSource = members;
            }));

            // update lbl count members info
            changeMemberCountEvent?.Invoke(members.Count);
        }

        private void Form_ChangeMembersCountEvent(int countMembers)
        {
            BeginInvoke(new Action(() =>
            {
                lblCountMembers.Text = $"Online members ({countMembers})";
            }));         
        }

        private void Client_SetNewClientIdEvent(FullMessage msg)
        {
            currentClientId = int.Parse(msg.Text);
        }

        private void Client_ReceiveMessageEvent(FullMessage msg)
        {
            BeginInvoke(new Action(() =>
            {
                var sours = allMembers.First(m => m.Id == msg.SourceId);

                string markAsPrivat = string.Empty;
                if (msg.IsPrivate)
                {
                    markAsPrivat = " (private)";
                }
                string fileInfo = string.Empty;
                if (msg.Type == MessageType.FileInfo)
                {
                    if (msg.SourceId != currentClientId)
                    {
                        fileInfo = ". You've got a new file!";
                        messageFilePath = msg.FilePath;
                        ShowFile();
                    }                      
                }
                rtbScreen.Text += $"{sours.NickName}{markAsPrivat}: {msg.Text}{fileInfo}\n";
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
        #endregion

        #region Btn_Click
        // first we need to get the nickname of the new member
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

                
                // send user NickName to server
                client.SendFullMessage(new FullMessage
                {
                    Text = tbNickName.Text,
                    Type = MessageType.ConnectNewClient,
                    IsPrivate = false
                });
            }
        }

        private void BtnSendForAll_Click(object sender, EventArgs e)
        {
            if (rtbMessage.Text != string.Empty || chBoxFileExists.Checked == true)
            {                
                FullMessage msg = new FullMessage();
                if (chBoxFileExists.Checked)
                {
                    msg.Type = MessageType.MessageWithFile;
                    // only send path because it's UI
                    msg.FilePath = messageFilePath;
                }
                else
                {
                    msg.Type = MessageType.Message;
                }

                msg.Text = rtbMessage.Text;
                msg.IsPrivate = false;
                msg.SourceId = currentClientId;

                client.SendFullMessage(msg);
                ClearEnteredText();                
            }
        }      

        private void BtnPrivatSend_Click(object sender, EventArgs e)
        {
            if (rtbMessage.Text != string.Empty || chBoxFileExists.Checked == true)
            {
                if (lbMembers.SelectedIndex != -1)
                {
                    FullMessage msg = new FullMessage();
                    if (chBoxFileExists.Checked)
                    {
                        msg.Type = MessageType.MessageWithFile;
                        msg.FilePath = messageFilePath;
                    }
                    else
                    {
                        msg.Type = MessageType.Message;
                    }

                    msg.Text = rtbMessage.Text;
                    msg.IsPrivate = true;
                    msg.SourceId = currentClientId;
                    msg.DestinationId = (lbMembers.SelectedItem as Member).Id;

                    client.SendFullMessage(msg);
                    ClearEnteredText();
                }
                else
                {
                    MessageBox.Show("You must first select a member for private message");
                }
            }              
        }

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

        private void BtnFile_Click(object sender, EventArgs e)
        {
            if(btnFile.Text == "New File")
            {
                btnFile.Text = string.Empty;
                fileMessageHasBeenSeen = true;
                Process.Start(messageFilePath);
                fileMessageHasBeenSeen = false;
            }
        }

        #endregion

        private void ClearEnteredText() => rtbMessage.Text = string.Empty;
    }
}
