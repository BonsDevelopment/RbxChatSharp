using RbxChatSharp.Model.ChatDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Core.Events
{
    public class LogEventArgs
    {
        public LogSender Sender = new LogSender();
        public BotReturn Bot = new BotReturn();
    }
}
