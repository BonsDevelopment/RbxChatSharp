using RbxChatSharp.Model.ChatDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Core.Events
{
    public class MessageReceivedEventArgs
    {
        public string Content { get; set; }
        public SenderClass Sender = new SenderClass();
        public char Prefix { get; set; }
        public Chat Chat = new Chat();

    }
}
