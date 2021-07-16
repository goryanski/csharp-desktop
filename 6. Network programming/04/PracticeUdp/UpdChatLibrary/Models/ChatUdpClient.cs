using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UpdChatLibrary.Helpers;

namespace UpdChatLibrary.Models
{
    public class ChatUdpClient
    {
        int localPort;
        string host;
        public event Action<UdpMessage> RecieveTextMessageEvent;
        public event Action<UdpMessage> RecieveFullMessageEvent;
        UdpMessage savedMessage = new UdpMessage();

        public ChatUdpClient(string host, int localPort) 
        {
            this.host = host;
            this.localPort = localPort;
        }

        public void Start()
        {
            UdpClient client = new UdpClient(localPort);
            IPEndPoint iPEndPoint = null;
            StartListenClient(client, iPEndPoint);
        }

        private void StartListenClient(UdpClient client, IPEndPoint iPEndPoint)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    byte[] tmp = client.Receive(ref iPEndPoint);
                    byte[] buff = new byte[500];
                    buff = tmp;

                    try
                    {
                        string json = Encoding.UTF8.GetString(buff, 0, buff.Length);
                        var msg = JsonConvert.DeserializeObject<UdpMessage>(json);

                        if (msg.Type == MessageType.OnlyText)
                        {
                            RecieveTextMessageEvent?.Invoke(msg);
                        }
                        else if (msg.Type == MessageType.WithFile)
                        {
                            msg.FilePath = $@"RecievedFiles\file_{Guid.NewGuid()}{msg.FileExtention}";
                            savedMessage = msg;                    
                        }                           
                    }
                    // если сообщение не типа UdpMessage - то есть файл, принимаем его в catch
                    catch (Exception)
                    {
                        using (var fs = new FileStream(savedMessage.FilePath, FileMode.Create, FileAccess.Write))
                        {
                            fs.Write(buff, 0, buff.Length);
                            do
                            {
                                byte[] tmp2 = client.Receive(ref iPEndPoint);
                                buff = tmp2;
                                fs.Write(buff, 0, buff.Length);                               
                            } while (buff.Length != 0);                       
                        }
                        RecieveFullMessageEvent?.Invoke(savedMessage);
                    }
                }
            });
        }

        public void SendMessage(UdpMessage message, UdpClient client)
        {
            if(message.Type == MessageType.OnlyText)
            {
                byte[] dgram = GetMessageBytes(message);
                client.Send(dgram, dgram.Length, host, message.DestinationPort);
            }
            else if(message.Type == MessageType.WithFile)
            {
                byte[] dgram = GetMessageBytes(message);
                client.Send(dgram, dgram.Length, host, message.DestinationPort);
                Thread.Sleep(1);

                using (var fs = new FileStream(message.FilePath, FileMode.Open, FileAccess.Read))
                {
                    int countReadBytes;
                    byte[] buff = new byte[500];
                    while ((countReadBytes = fs.Read(buff, 0, buff.Length)) != 0)
                    {
                        client.Send(buff, countReadBytes, host, message.DestinationPort);
                        Thread.Sleep(1);
                    }
                    Thread.Sleep(100);
                    client.Send(new byte[] { }, 0, host, message.DestinationPort);
                }
            }
        }

        byte[] GetMessageBytes(UdpMessage message)
        {
            string json = JsonConvert.SerializeObject(message);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
