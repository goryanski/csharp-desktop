using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatLibrary.Models.Client;
using Newtonsoft.Json;

namespace ChatLibrary.Models
{
    public class FullMessage : IMessage, IFileMessage
    {
        public string Text { get; set; }
        public MessageType Type { get; set; }       
        public bool IsPrivate { get; set; }
        public int SourceId { get; set; } 
        public int DestinationId { get; set; }

        public string FilePath { get; set; }
        public string Extension { get; set; }
        public byte[] Data { get; set; }
        public int CountBites { get; set; }
        public int CountPackages { get; set; }
    }
}
