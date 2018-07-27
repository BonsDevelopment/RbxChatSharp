using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Model.Json.Chat
{
    public class Participant
    {
        public string type { get; set; }
        public int targetId { get; set; }
        public string name { get; set; }
    }
}
