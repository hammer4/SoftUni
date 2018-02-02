using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _07._Directory_Traversal
{
    class Program
    {
        static void Main()
        {
            string directory = "./";
            string[] files = Directory.GetFiles(directory);
            Dictionary<string, Dictionary<string, double>> dictionary = new Dictionary<string, Dictionary<string, double>>();
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (dictionary.ContainsKey(fileInfo.Extension))
                {

                    dictionary[fileInfo.Extension].Add(fileInfo.Name, fileInfo.Length);
                }
                else
                {
                    Dictionary<string, double> dict = new Dictionary<string, double>();
                    dict.Add(fileInfo.Name, fileInfo.Length);
                    dictionary.Add(fileInfo.Extension, dict);
                }
            }

            StreamWriter writer = new StreamWriter("C:\\Users\\Public\\Desktop\\report.txt");
            using (writer)
            {
                foreach (KeyValuePair<string, Dictionary<string, double>> keyvalue in dictionary.OrderByDescending(k => k.Value.Count).ThenBy(name => name.Key))
                {
                    writer.WriteLine(keyvalue.Key);
                    foreach (KeyValuePair<string, double> kv in keyvalue.Value.OrderBy(size => size.Value))
                    {
                        writer.WriteLine("--" + kv.Key + " - {0:F3}kb", kv.Value / 1024);
                    }
                }
            }
        }
    }
}
