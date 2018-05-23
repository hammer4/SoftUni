using System;
using System.Net;
using System.Text;

public class Program
{
    public static void Main()
    {
        var urlInput = Console.ReadLine();
        var decodedUrl = WebUtility.UrlDecode(urlInput);

        try
        {
            var parsedUrl = new Uri(decodedUrl);

            // Required URL components
            if (string.IsNullOrWhiteSpace(parsedUrl.Scheme) ||
                string.IsNullOrWhiteSpace(parsedUrl.Host) ||
                string.IsNullOrWhiteSpace(parsedUrl.LocalPath) ||
                !parsedUrl.IsDefaultPort)
            {
                throw new ArgumentException("Invalid URL");
            }

            var builder = new StringBuilder();
            builder
                .AppendLine($"Protocol: {parsedUrl.Scheme}")
                .AppendLine($"Host: {parsedUrl.Host}")
                .AppendLine($"Port: {parsedUrl.Port}")
                .AppendLine($"Path: {parsedUrl.LocalPath}");

            // Optional URL components
            if (!string.IsNullOrWhiteSpace(parsedUrl.Query))
            {
                builder.AppendLine($"Query: {parsedUrl.Query.Substring(1)}");
            }

            if (!string.IsNullOrWhiteSpace(parsedUrl.Fragment))
            {
                builder.AppendLine($"Fragment: {parsedUrl.Fragment.Substring(1)}");
            }

            Console.WriteLine(builder.ToString().Trim());
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid URL");
        }
    }
}
