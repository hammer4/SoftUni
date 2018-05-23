using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace _03._Request_Parser
{
    class Program
    {
        public static void Main()
        {
            var validUrlMethods = ReadValidUrls();
            ProcessHttpRequest(validUrlMethods);
        }

        private static void ProcessHttpRequest(Dictionary<string, HashSet<string>> validUrlMethods)
        {
            var request = Console.ReadLine();
            var requestTokens = request.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var requestMethod = requestTokens[0].ToLower();
            var requestUrl = requestTokens[1];
            var requestProtocol = requestTokens[2];

            var statusCode = validUrlMethods.ContainsKey(requestUrl) &&
                             validUrlMethods[requestUrl].Contains(requestMethod)
                             ? HttpStatusCode.OK
                             : HttpStatusCode.NotFound;

            var builder = new StringBuilder();
            builder
                .AppendLine($"{requestProtocol} {(int)statusCode} {statusCode}")
                .AppendLine($"Content-Length: {statusCode.ToString().Length}")
                .AppendLine($"Content-Type: text/plain" + Environment.NewLine)
                .AppendLine($"{statusCode}");

            Console.WriteLine(builder.ToString().Trim());
        }

        private static Dictionary<string, HashSet<string>> ReadValidUrls()
        {
            var validUrls = new Dictionary<string, HashSet<string>>(); // URL, http methods

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                var inputTokens = input.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                var path = inputTokens[0];
                var method = inputTokens[1].ToLower();
                var fullPath = "/" + path;

                if (!validUrls.ContainsKey(fullPath))
                {
                    validUrls[fullPath] = new HashSet<string>();
                }

                validUrls[fullPath].Add(method);
            }

            return validUrls;
        }
    }
}
