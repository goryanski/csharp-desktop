using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChatLibrary.Models.Base
{
    public abstract class BaseConnection
    {
        protected readonly string host;
        protected readonly int port;
        protected readonly Socket socket;
        protected readonly IPEndPoint iPEndPoint;
        protected const int PACKAGE_SIZE = 500;

        public BaseConnection(string host, int port)
        {
            this.host = host;
            this.port = port;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            iPEndPoint = new IPEndPoint(IPAddress.Parse(host), port);
            Init();
        }

        protected abstract void Init();

        protected virtual FullMessage ReceiveMessage(Socket client)
        {
            byte[] buff = new byte[PACKAGE_SIZE];
            int countReceiveBytes = client.Receive(buff);
            string json = Encoding.UTF8.GetString(buff, 0, countReceiveBytes);
            var msg = JsonConvert.DeserializeObject<FullMessage>(json);
            return msg;
        }
        protected void SendMessage(Socket receiver, FullMessage message)
        {
            string json = JsonConvert.SerializeObject(message);
            byte[] buff = Encoding.UTF8.GetBytes(json);
            receiver.Send(buff);
        }

        protected void SendFileData(Socket receiver, byte[] data)
        {
            receiver.Send(data);
        }

        protected virtual byte[] ReceiveFileData(Socket client)
        {
            
            byte[] buff = new byte[PACKAGE_SIZE];
            client.Receive(buff);
            return buff;
        }
    }
}
