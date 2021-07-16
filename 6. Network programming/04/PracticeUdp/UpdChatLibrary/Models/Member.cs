using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdChatLibrary.Models
{
    [Serializable]
    public class Member
    {
        public string NickName { get; set; }
        public int Port { get; set; }

        //public string Host { get; set; } // now we don't need it

        public override string ToString() => $"{NickName}";
    }
}
