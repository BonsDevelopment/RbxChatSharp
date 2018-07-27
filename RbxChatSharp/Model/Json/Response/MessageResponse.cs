using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Model.Json.Response
{
    public class MessageResponse
    {

        //{"messageId":"8ee53cf4-7ef4-4b89-a7b5-8cd38ca2428c","sent":"2018-06-22T03:07:41.3384327Z","content":"ey","filteredForReceivers":false,"messageType":"PlainText","resultType":"Success","statusMessage":"Successfully sent the message"}
        public string messageId { get; set; }
        public string content { get; set; }
        public bool filteredForReceivers { get; set; }
        public string messageType { get; set; }
        public string resultType { get; set; }
        public string statusMessage { get; set; }
    }
}
