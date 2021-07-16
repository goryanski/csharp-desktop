using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatLibrary.Models.Server;

namespace PracticePrivatChat
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatServer server = new ChatServer("127.0.0.1", 55_000);
            server.Start();
        }
    }
}
