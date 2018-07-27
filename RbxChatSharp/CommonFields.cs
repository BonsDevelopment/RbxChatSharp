using RbxChatSharp.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp
{
    public static class CommonFields
    {
      public static HttpClientHandler httpClientHandler = new HttpClientHandler()
        {
            AllowAutoRedirect = false,
            PreAuthenticate = true,
        };
  
        public static HttpClient GlobalHttpClient = new HttpClient(httpClientHandler, false);
 
        public static  LogEventArgs l1 = new LogEventArgs();

        public static NewWebClient wClient;
    }
}
