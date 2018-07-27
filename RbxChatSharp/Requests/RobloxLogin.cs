using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Requests
{
    public class RobloxLogin
    {
       
        static private Dictionary<string, string> credentialDictionary;

        public RobloxLogin(string Username, string Password)
        {          

            credentialDictionary = new Dictionary<string, string>();


            credentialDictionary.Add("username", Username);
            credentialDictionary.Add("password", Password);
        }

        public async Task<Tuple<bool, string>> Login()
        {
           CommonFields.GlobalHttpClient.DefaultRequestHeaders.Add("X-CSRF-TOKEN", GetXSRFToken());

            CommonFields.GlobalHttpClient.DefaultRequestHeaders.ConnectionClose = true;
            using (var content = new FormUrlEncodedContent(credentialDictionary))
            {
                
                using (var result = await CommonFields.GlobalHttpClient.PostAsync(EndPoints.Login, content))
                {
                    IEnumerable<string> cookieHeader;

                    result.Headers.TryGetValues("Set-Cookie", out cookieHeader);
                    if (cookieHeader != null)
                    {
                        foreach (var item in cookieHeader)
                        {
                            if (item.Contains(".ROBLO"))
                            {
                                return new Tuple<bool, string>(true, item);
                            }
                        }

                    }
                    return new Tuple<bool, string>(false, String.Empty);
                }
            }
        }

        private string GetXSRFToken()
        {
            using (HttpResponseMessage response = CommonFields.GlobalHttpClient.GetAsync("https://www.roblox.com/").Result)
            {
                using (HttpContent content = response.Content)
                {
                    return Parsing.StringParser.Parse("Roblox.XsrfToken.setToken('", "');", content.ReadAsStringAsync().Result);
                }
            }
        }


    }
}
