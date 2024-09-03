using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NotificationChannelParser
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputs = new List<string>
            {
                "[BE][FE][Urgent] there is error",
                "[BE][QA][HAHA][Urgent] there is error"
            };

            foreach (var input in inputs)
            {
                string result = ParseNotificationChannels(input);
                Console.WriteLine(result);
            }
        }

        static string ParseNotificationChannels(string input)
        {
            HashSet<string> validTags = new HashSet<string> { "BE", "FE", "QA", "Urgent" };
            string pattern = @"\[(.*?)\]";
            MatchCollection matches = Regex.Matches(input, pattern);
            List<string> channels = new List<string>();
            foreach (Match match in matches)
            {
                string tag = match.Groups[1].Value;
                if (validTags.Contains(tag))
                {
                    channels.Add(tag);
                }
            }
            string channelList = string.Join(", ", channels);
            return $"Receive channels: {channelList}";
        }
    }
}
