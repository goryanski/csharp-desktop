using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChatLibrary.Models.Base;
using Newtonsoft.Json;

namespace ChatLibrary.Models.Client
{
    public class ChatClient : BaseConnection
    {
        public event Action<string> ConnectFailedEvent;
        public event Action<string> WrongFileExeptionEvent;
        public event Action<List<Member>> ReceiveListClientsEvent;
        public event Action<FullMessage> ReceiveMessageEvent;
        public event Action<FullMessage> SetNewClientIdEvent;
        public event Action FileSentEvent;

        public ChatClient(string host, int port) : base(host, port)
        {          
        }

        protected override void Init()
        {
            try
            {
                socket.Connect(iPEndPoint);
            }
            // Just skip it now, we will catch the Exception in StartListening
            catch (Exception) { }                   
        }

        public void StartListening()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {                    
                        var msg = ReceiveMessage(socket);

                        switch (msg.Type)
                        {
                            case MessageType.FileInfo:
                            case MessageType.Message:
                                ReceiveMessageEvent?.Invoke(msg);
                                break;
                            case MessageType.ClientsList:
                                TakeClientsList(msg);
                                break;
                            case MessageType.SetId:
                                SetNewClientIdEvent?.Invoke(msg);
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        // if the server did not start or shut down
                        ConnectFailedEvent?.Invoke("The server is not responding. The app doesn't work, please try again later");
                        break;
                    }
                }
            });
        }

        private void TakeClientsList(FullMessage msg)
        {            
            List<Member> listClients = JsonConvert.DeserializeObject<List<Member>>(msg.Text);
            ReceiveListClientsEvent?.Invoke(listClients);
        }

        public void SendFullMessage(FullMessage message)
        {
            switch (message.Type)
            {
                case MessageType.MessageWithFile:
                    SendMessageWithFile(socket, message);
                    break;
                default:
                     SendMessage(socket, message);
                    break;
            }           
        }

        private void SendMessageWithFile(Socket socket, FullMessage message)
        {         
            try
            {
                int countSendPackages = GetCountPackages(message.FilePath, PACKAGE_SIZE);
               
                // send file info
                SendMessage(socket, new FullMessage
                {
                    Text = message.Text,
                    Type = MessageType.FileInfo,
                    IsPrivate = message.IsPrivate,
                    SourceId = message.SourceId,
                    CountPackages = countSendPackages,
                    Extension = Path.GetExtension(message.FilePath),
                    DestinationId = message.DestinationId,
                });
                
                Thread.Sleep(100);

                using (var fs = new FileStream(message.FilePath, FileMode.Open, FileAccess.Read))
                {
                    
                    while (countSendPackages > 0)
                    {
                        byte[] buff = new byte[PACKAGE_SIZE];
                        int countBytes = fs.Read(buff, 0, buff.Length);

                        SendFileData(socket, buff);                     
                        countSendPackages--;
                    }
                    
                }
                FileSentEvent?.Invoke();
            }
            catch (Exception ex)
            {
                WrongFileExeptionEvent?.Invoke($"Wrong File! {ex.Message}");
            }
        }

        int GetCountPackages(string path, int packageSize)
        {
            int countPackages = 0;
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                countPackages = (int)(fs.Length / packageSize);
                countPackages += (countPackages * packageSize == fs.Length) ? 0 : 1;
            }
            return countPackages;
        }
    }
}