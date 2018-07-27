using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Model.Json.MsgListen
{
    public class MsgChatObject
    {
        public int conversationId { get; set; }
        public List<ChatMessage> chatMessages { get; set; }
    }
}
