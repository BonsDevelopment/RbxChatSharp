using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp
{
    public static class EndPoints
    {
        public static readonly string Conversation = "https://chat.roblox.com/v2/get-user-conversations?pageNumber=1&pageSize=400";
        public static readonly string SendMessage = "https://chat.roblox.com/v2/send-message";
        public static readonly string ConversationId = "http://chat.roblox.com/v2/multi-get-latest-messages?conversationIds=";
        public static readonly string Typing = "https://chat.roblox.com/v2/update-user-typing-status";
        public static readonly string Login = "https://www.roblox.com/NewLogin";
    }
}
