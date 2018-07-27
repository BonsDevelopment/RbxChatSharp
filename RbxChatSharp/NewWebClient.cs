using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp
{
    public class NewWebClient : WebClient
    {
        public NewWebClient(string Cookie)
        {
            this.Headers.Add(HttpRequestHeader.Cookie, Cookie);
        }
    }
}
