using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Model.Json.MsgListen
{
    public class ChatMessage
    {
        public string id { get; set; }
        public int senderTargetId { get; set; }
        public string senderType { get; set; }
        public string content { get; set; }
        public DateTime sent { get; set; }
        public bool read { get; set; }
        public string messageType { get; set; }
    }
}
