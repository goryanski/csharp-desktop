using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatLibrary.Models.Client;

namespace ChatLibrary.Models
{
    public enum MessageType
    {
        Message,
        ConnectNewClient,
        ClientsList,
        SetId,
        MessageWithFile,
        FileInfo,
        FileData
    }
    public interface IMessage
    {
        string Text { get; set; }
        MessageType Type { get; set; }
        bool IsPrivate { get; set; }
        int SourceId { get; set; }
        int DestinationId { get; set; }
    }
}
