using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.URL_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = Console.ReadLine();
            string protocol = "";
            string server = "";
            string resource = "";

            int protocolEndIndex = url.IndexOf("://");
            string serverAndResource= url;

            if (protocolEndIndex != -1)
            {
                protocol = url.Substring(0, protocolEndIndex);
                serverAndResource = url.Substring(protocol.Length + 3, url.Length - protocol.Length - 3);
            }

            int serverEndIndex = serverAndResource.IndexOf("/");

            if(serverEndIndex != -1)
            {
                server = serverAndResource.Substring(0, serverEndIndex);
                resource = serverAndResource.Substring(server.Length + 1, serverAndResource.Length - server.Length - 1);
            }
            else
            {
                server = serverAndResource;
            }

            Console.WriteLine("[protocol] = \"{0}\"", protocol);
            Console.WriteLine("[server] = \"{0}\"", server);
            Console.WriteLine("[resource] = \"{0}\"", resource);
        }
    }
}
