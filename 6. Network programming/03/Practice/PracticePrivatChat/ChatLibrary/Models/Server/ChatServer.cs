using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ChatLibrary.Models.Base;
using ChatLibrary.Models.Client;
using Newtonsoft.Json;

namespace ChatLibrary.Models.Server
{
    public class ChatServer : BaseConnection
    {
        List<Member> connectedClients = new List<Member>();
        int idCounter = 0;
        int countReceivePackages;
        event Action<Socket, FullMessage> EndingRecieveFile;

        public ChatServer(string host, int port) : base(host, port)
        {
            EndingRecieveFile += ChatServer_EndingRecieveFile;
        }


        protected override void Init()
        {
            socket.Bind(iPEndPoint);
            socket.Listen(5);
        }

        public void Start()
        {
            Console.WriteLine("Server has been started!");
            while (true)
            {
                Console.WriteLine("Wait client...");

                Socket client = socket.Accept();
                StartListenClient(client);
                Console.WriteLine($"Client {client.RemoteEndPoint} was connected...");
            }
        }

        private void StartListenClient(Socket client)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        var msg = ReceiveMessage(client);
                        ProcessReceiveMessage(client, msg);
                    }
                    catch (Exception)
                    {
                        // if client closed his app end left the chat
                        var leftClient = connectedClients.FirstOrDefault(c => c.Socket == client);

                        // if client not even send his name before he left - he wasn't really connected
                        if (leftClient != null)
                        {
                            connectedClients.Remove(leftClient);

                            // we need to update list of connected clients in UI, when one of the clients left the chat
                            UpdateClientsListForConnectedClients();
                        }

                        Console.WriteLine($"Client {client.RemoteEndPoint} was disconnected...");
                        Console.WriteLine("Wait client...");
                        break;
                    }
                }
            });
        }

        private void ProcessReceiveMessage(Socket client, FullMessage msg)
        {
            
            switch (msg.Type)
            {
                case MessageType.Message:
                    ResendClientMessage(msg, client);
                    break;
                case MessageType.ConnectNewClient:
                    ConnectNewClient(client, msg);
                    break;
                case MessageType.FileInfo:
                    StartRecieveFile(client, msg);                                   
                    break;
            }
        }

        private void StartRecieveFile(Socket client, FullMessage msg)
        {
            countReceivePackages = msg.CountPackages;
            string newPath = $@"RecievedFiles\file_{Guid.NewGuid()}{msg.Extension}";
            // save path to UI
            msg.FilePath = Path.GetFullPath(newPath);

            using (var fs = new FileStream(newPath, FileMode.Create, FileAccess.Write))
            {
                while (countReceivePackages != 0)
                {                    
                    try
                    {
                        var data = ReceiveFileData(client);
                        fs.Write(data, 0, data.Length);
                    }
                    //if client will close his app before file completely sent, this Exception we will catch in StartListen Client, so just skip it here 
                    catch (Exception) { }

                    countReceivePackages--;
                }       
            }
            EndingRecieveFile?.Invoke(client, msg);
        }

      
        private void ConnectNewClient(Socket socket, FullMessage msg)
        {
            Member newClient = new Member
            {
                NickName = msg.Text,
                Id = ++idCounter,
                Socket = socket
            };

            // we need to have new client id in UI
            SendIdForNewClient(newClient);
            connectedClients.Add(newClient);

            // we need to update list of connected clients in UI, when new client was added
            UpdateClientsListForConnectedClients();
        }

        private void SendIdForNewClient(Member newClient)
        {
            var msg = new FullMessage
            {               
                Text = newClient.Id.ToString(),
                Type = MessageType.SetId,
                IsPrivate = true
            };
            SendMessage(newClient.Socket, msg);
        }

        private void UpdateClientsListForConnectedClients()
        {
            var msg = new FullMessage
            {
                Text = JsonConvert.SerializeObject(connectedClients),
                Type = MessageType.ClientsList,
                IsPrivate = false
            };       
            ResendClientMessage(msg);
        }

        private void ResendClientMessage(FullMessage msg, Socket sourse = null)
        {
            if (msg.IsPrivate)
            {
                var destinationClient = connectedClients.First(c => c.Id == msg.DestinationId);
                SendMessage(destinationClient.Socket, msg);
                // sender must see his message too
                SendMessage(sourse, msg);
            }
            else
            {
                connectedClients.ForEach(client =>
                {
                   SendMessage(client.Socket, msg); 
                });
            }
        }

        private void ChatServer_EndingRecieveFile(Socket client, FullMessage msg)
        {
            // now we can send message text (which with file)
            ResendClientMessage(msg, client);
        }
    }
}