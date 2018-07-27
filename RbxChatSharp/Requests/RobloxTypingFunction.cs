using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Requests
{
    public static class RobloxTypingFunction
    {
        public async static void Typing(string ChatID)
        {
            await Task.Delay(300);
            using (var httpContent = new StringContent("{ \"conversationId\":" + ChatID + ",\"isTyping\":true}", Encoding.UTF8, "application/json"))
            {
                using (var result = await CommonFields.GlobalHttpClient.PostAsync(EndPoints.Typing, httpContent))
                {
                    var contents = await result.Content.ReadAsStringAsync();                   
                }
            }
        }

    }
}
