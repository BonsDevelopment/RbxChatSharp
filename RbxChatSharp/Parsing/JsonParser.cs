using Newtonsoft.Json;
using RbxChatSharp.Model.Json.Chat;
using RbxChatSharp.Model.Json.MsgListen;
using RbxChatSharp.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Parsing
{
    public static class JsonParser
    {
      
        public static List<T> ParseJson<T>(string Url)
        {
            return JsonConvert.DeserializeObject<List<T>>(CommonFields.wClient.DownloadString(Url));
        }

        public static List<MsgChatObject> ParseChat(string id)
        {
            var json = JsonConvert.DeserializeObject<List<MsgChatObject>>(CommonFields.wClient.DownloadString($"{EndPoints.ConversationId}{id}&pageSize=1"));
            return json;
        }
    }
}
