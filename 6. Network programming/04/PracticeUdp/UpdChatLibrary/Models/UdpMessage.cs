using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdChatLibrary.Models
{
    public class UdpMessage : IUpdMessage
    {
        public string Text { get; set; }
        public MessageType Type { get; set; }
        public Member Member { get; set; }
        public int DestinationPort { get; set; }
        public string FilePath { get; set; }
        public string DestinationFilePath { get; set; }
        public string FileExtention { get; set; }
    }
}
