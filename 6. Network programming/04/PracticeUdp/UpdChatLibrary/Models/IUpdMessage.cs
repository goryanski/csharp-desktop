using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdChatLibrary.Models
{
    public enum MessageType
    {
        OnlyText,
        WithFile,
    }

    public interface IUpdMessage
    {
        string Text { get; set; }
        MessageType Type { get; set; }
        Member Member { get; set; }
        int DestinationPort { get; set; }
        string FilePath { get; set; }
        string DestinationFilePath { get; set; }
        string FileExtention { get; set; }
    }
}
