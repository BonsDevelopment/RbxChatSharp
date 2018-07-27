using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Model.Json.Chat
{
    public class Initiator
    {
        public string type { get; set; }
        public int targetId { get; set; }
        public object name { get; set; }
    }
}
