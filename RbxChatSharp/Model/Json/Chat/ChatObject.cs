using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Model.Json.Chat
{
    public class ChatObject
    {
        public int id { get; set; }
        public string title { get; set; }
        public Initiator initiator { get; set; }
        public bool hasUnreadMessages { get; set; }
        public List<Participant> participants { get; set; }
        public string conversationType { get; set; }
        public ConversationTitle conversationTitle { get; set; }
        public DateTime lastUpdated { get; set; }
        public object conversationUniverse { get; set; }
    }
}
