using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Model.ChatDetails
{
    public abstract class RbxChatBase
    {
        public string Handle { get; set; }
        public string Message { get; set; }
    }
}
