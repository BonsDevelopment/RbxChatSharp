using Newtonsoft.Json;
using RbxChatSharp.Core.Events;
using RbxChatSharp.Model.Json.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Requests
{
    public class RobloxSendMessage
    {
        public static event EventHandler<LogEventArgs> LogEvent;

        public static async void SendMessage(string msg, string chatID)
        {
            try
            {
                int filteredCount = msg.Count(x => (x == '#'));

                if (filteredCount > 1)
                {
                    SendMessage("Invalid Request", chatID);
                    CommonFields.l1.Bot.Responded = false;
                    return;
                }


                //CommonFields.GlobalHttpClient.DefaultRequestHeaders.Clear();
                //CommonFields.GlobalHttpClient.DefaultRequestHeaders.Add("Cookie", $"{Authentication.Cookie}");
                //CommonFields.GlobalHttpClient.DefaultRequestHeaders.Add("X-CSRF-TOKEN", Authentication.Token);

                using (var httpContent = new StringContent("{\"conversationId\":\"" + chatID + "\"," + "\"message\":\"" + msg + "\"}", Encoding.UTF8, "application/json"))
                {
                    using (var result = await CommonFields.GlobalHttpClient.PostAsync(EndPoints.SendMessage, httpContent))
                    {
                        var contents = await result.Content.ReadAsStringAsync();
                        var jsonResult = JsonConvert.DeserializeObject<MessageResponse>(contents);

                        bool resultType = jsonResult.resultType == "Success";

                        if (!resultType)
                        {
                            ErroredResponse(ref CommonFields.l1, "Moderated Response", chatID);
                            return;
                        }

                        if (msg != "Moderated Response")
                        {
                            CommonFields.l1.Bot.Responded = resultType;
                            CommonFields.l1.Bot.Response = msg;
                            LogEvent?.Invoke(null, CommonFields.l1);
                        }
                    }
                }
            }
            catch (System.Net.WebException)
            {
                ErroredResponse(ref CommonFields.l1, "Moderated Response", chatID);
            }
            
        }


        private static void ErroredResponse(ref LogEventArgs logEvent, string Response, string ID)
        {
            logEvent.Bot.Responded = false;
            logEvent.Bot.Response = Response;
            SendMessage(Response, ID);
            LogEvent?.Invoke(null, logEvent);
        }
    }
}
