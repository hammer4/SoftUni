using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _09._HTTP_Server
{
    class Program
    {
        const int PortNumber = 1337;
        const string SourcePath = "../Resources";
        static void Main(string[] args)
        {
            var tcpListener = new TcpListener(IPAddress.Any, PortNumber);
            tcpListener.Start();

            Console.WriteLine($"Listening on port {PortNumber}...");
            Console.WriteLine($"The local End point is : localhost:{PortNumber}");

            while (true)
            {
                using (NetworkStream networkStream = tcpListener.AcceptTcpClient().GetStream())
                {
                    var request = new byte[4096];
                    var readBytes = networkStream.Read(request, 0, request.Length);

                    var reqData = Encoding.UTF8.GetString(request, 0, readBytes).Replace("\\", "/");
                    Console.WriteLine(reqData);

                    if (!string.IsNullOrEmpty(reqData))
                    {
                        var file = string.Empty;

                        var reqFirstLine = reqData.Substring(0, reqData.IndexOf(Environment.NewLine)).Split();
                        var url = reqFirstLine[1];
                        var statusLine = $"{reqFirstLine[2]} 200 OK";

                        if (url == "/")
                        {
                            file = $"{SourcePath}/index.html";
                        }
                        else
                        {
                            var reqFile = $"{SourcePath}{url.Substring(url.IndexOf('/'))}";

                            if (!reqFile.EndsWith(".html"))
                            {
                                reqFile += ".html";
                            }

                            if (File.Exists(reqFile))
                            {
                                file = reqFile;
                            }
                            else
                            {
                                file = $"{SourcePath}/error.html";
                            }
                        }

                        // Build Response Header
                        var responseHeader = new StringBuilder();
                        responseHeader.Append($"{statusLine}{Environment.NewLine}");
                        responseHeader.Append($"Accept-Ranges: bytes{Environment.NewLine}");

                        // Build Response message
                        var response = new StringBuilder();

                        if (String.IsNullOrEmpty(file))
                        {
                            continue;
                        }

                        using (var reader = new StreamReader(file))
                        {
                            var line = reader.ReadLine();

                            while (line != null)
                            {
                                response.Append(line);
                                line = reader.ReadLine();
                            }
                        }

                        if (file.EndsWith("info.html"))
                        {
                            response
                                .Replace("{0}", DateTime.Now.ToString("dd MMM yyyy hh:mm:ss"))
                                .Replace("{1}", Environment.ProcessorCount.ToString());
                        }

                        // Complete response Headder
                        var contentLingth = Encoding.UTF8.GetBytes(response.ToString()).Length;

                        responseHeader.Append($"ContentLength: {contentLingth}{Environment.NewLine}");
                        responseHeader.Append($"Connection: close{Environment.NewLine}");
                        responseHeader.Append($"Content-Type: text/html{Environment.NewLine}");
                        responseHeader.Append(Environment.NewLine);

                        // Gather together Header and Message for the response
                        response.Insert(0, responseHeader);

                        // Convert response to bytes
                        var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

                        // Send Rresponse to the Browser
                        networkStream.Write(responseBytes, 0, responseBytes.Length);
                    }
                }
            }
        }
    }
}
