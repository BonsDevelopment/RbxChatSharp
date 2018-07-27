using RbxChatSharp.Core.Events;
using RbxChatSharp.Model.Json.Chat;
using RbxChatSharp.Parsing;
using RbxChatSharp.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RbxChatSharp.Core.Bot
{
    public class MessageListener
    {

        public char Prefix { get; set; }
        public object RbxChatFunctions { get; private set; }

        public event EventHandler<MessageReceivedEventArgs> MessageReceived;


        //exposing the event 
        public event EventHandler<LogEventArgs> LogEvent
        {
            add   { RobloxSendMessage.LogEvent += value; }
            remove { RobloxSendMessage.LogEvent -= value; }
        }

        private static Timer msgListenerStart;


        public void Start()
        {
            msgListenerStart = new Timer(TimerCallback, null, 0, 430);            
        }

        private void TimerCallback(object o)
        {
            var li = JsonParser.ParseJson<ChatObject>(EndPoints.Conversation);

            foreach (var item in li)
            {
                if (item.hasUnreadMessages)
                {
                    string content = JsonParser.ParseChat(item.id.ToString())[0].chatMessages[0].content;

                    if (content[0] == Prefix)
                    {
                        MessageReceivedEventArgs m1 = new MessageReceivedEventArgs();
                        m1.Sender.Handle = item.title.ToString();
                        m1.Sender.ChatID = item.id.ToString();
                        m1.Sender.Message = content.Replace(content, "");
                        m1.Chat.Functions.ShowTyping = RobloxTypingFunction.Typing;

                        StringParser.SeparateMsg(ref m1, content);

                        m1.Prefix = Prefix;
                        m1.Chat.SendMessage = RobloxSendMessage.SendMessage;


                        CommonFields.l1.Sender.Message = content;
                        CommonFields.l1.Sender.Handle = item.title;

                        MessageReceived?.Invoke(this, m1);
                    }
                }

            }
        }

    }
}
