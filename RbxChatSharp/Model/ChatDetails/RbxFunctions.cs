using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Model.ChatDetails
{
    public delegate void TypingDelegate(string ChatID);
    public class RbxFunctions
    {
        public TypingDelegate ShowTyping { get; set; }
    }

}
