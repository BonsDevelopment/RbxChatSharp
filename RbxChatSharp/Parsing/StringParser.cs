using RbxChatSharp.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RbxChatSharp.Parsing
{
    public static class StringParser
    {
        public static string Parse(string bDelimiter, string eDelimter, string fString)
        {
            int beginIndex = fString.IndexOf(bDelimiter) + bDelimiter.Length;
            int endIndex = fString.IndexOf(eDelimter, beginIndex);

            return fString.Substring(beginIndex, endIndex - beginIndex);
        }

        public static void SeparateMsg(ref MessageReceivedEventArgs msg, string content)
        {
            string[] cmd = content.Split(' ');

            if (cmd.Length < 2)
            {
                msg.Sender.Command = content.Substring(1);

            }
            else
            {
                msg.Sender.Command = cmd[0].Substring(1);
                msg.Sender.Message = content.Replace($"{cmd[0]} ", "");
            }
        }
    }
}
