using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChatLibrary.Models.Client
{
    public class Member
    {
        public string NickName { get; set; }
        public int Id { get; set; }

        [JsonIgnore] // Json can't serialize socket, besides we don't need to do it
        public Socket Socket { get; set; } 

        public override string ToString() => $"{NickName}";
    }
}
