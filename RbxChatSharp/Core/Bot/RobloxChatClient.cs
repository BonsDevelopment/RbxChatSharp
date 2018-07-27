using RbxChatSharp.Core.Events;
using RbxChatSharp.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Core.Bot
{
    public class RobloxChatClient
    {
        public string Username { get; set; }
        public string Password { get; set; }


        public event EventHandler<LoginEventArgs> Connected;

        public Task SendLoginRequest()
        {

            return Task.Run(async () =>
            {
                RobloxLogin r1 = new RobloxLogin(Username, Password);


                Tuple<bool, string> loginResponse = await r1.Login();

                if (loginResponse.Item1)
                {
                    Authentication.Cookie = loginResponse.Item2;
                    Authentication.Token = GetToken(Authentication.Cookie);
                    LoginEventArgs l1 = new LoginEventArgs() { Username = Username };

                    InitializeHeaders();

                    Connected?.Invoke(this, l1);

                }
            });
        }


        private static void InitializeHeaders()
        {
            CommonFields.GlobalHttpClient.DefaultRequestHeaders.Clear();
            CommonFields.GlobalHttpClient.DefaultRequestHeaders.Add("Cookie", $"{Authentication.Cookie}");
            CommonFields.GlobalHttpClient.DefaultRequestHeaders.Add("X-CSRF-TOKEN", Authentication.Token);
            CommonFields.wClient = new NewWebClient(Authentication.Cookie);
        }

        private static string GetToken(string cookie)
        {
            using (WebClient wb = new WebClient())
            {
                wb.Headers.Add(HttpRequestHeader.Cookie, cookie);
                string g = wb.DownloadString("https://www.roblox.com/home");

                return Parsing.StringParser.Parse("Roblox.XsrfToken.setToken('", "');", g);
            }
        }

        
    }
}
