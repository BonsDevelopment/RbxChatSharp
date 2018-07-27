using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Model.ChatDetails
{
    public class Chat
    {
        public delegate void SendMessageDelegate(string Msg, string ChatID);

        public SendMessageDelegate SendMessage { get; set; }
        public RbxFunctions Functions = new RbxFunctions();
       // public TypingDelegate StartTyping { get; set; }
    }
}
