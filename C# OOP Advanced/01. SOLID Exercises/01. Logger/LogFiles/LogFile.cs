using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class LogFile : ILogFile
{
    private string path = "../../../log.txt";

    public LogFile()
    {
        FileStream fs = new FileStream(path, FileMode.Create);
        fs.Close();
    }

    public int Size
    {
        get
        {
            using(var stream = new StreamReader(path))
            {
                return stream.ReadToEnd().ToCharArray()
                    .Where(Char.IsLetter)
                    .Sum(c => c);
            }
        }
    }

    public void Write(string content)
    {
        using (var stream = new StreamWriter(path, true))
        {
            stream.WriteLine(content);
        }
    }
}