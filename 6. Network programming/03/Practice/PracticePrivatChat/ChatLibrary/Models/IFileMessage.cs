using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibrary.Models
{
    public interface IFileMessage
    {
        string FilePath { get; set; }
        string Extension { get; set; }
        byte[] Data { get; set; }
        int CountBites { get; set; }
        int CountPackages { get; set; }
    }
}
