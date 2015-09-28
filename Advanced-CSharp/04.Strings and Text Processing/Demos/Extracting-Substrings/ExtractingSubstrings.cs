using System;
using System.IO;

public class ExtractingSubstrings
{
    public static void Main()
    {
        const string FileName = @"C:\Pics\Rila2005.jpg";
        Console.WriteLine("Full file name: {0}", FileName);

        string pathOnly = ExtractPath(FileName);
        Console.WriteLine("Path: {0}", pathOnly);

        string fileNameOnly = ExtractFileName(FileName);
        Console.WriteLine("File name only: {0}", fileNameOnly);

        string extension = ExtractExtension(FileName);
        Console.WriteLine("File extension: {0}", extension);
    }

    private static string ExtractExtension(string fileName)
    {
        string extension = string.Empty;

        int dotIndex = fileName.LastIndexOf('.');

        if (dotIndex != -1)
        {
            extension = fileName.Substring(dotIndex + 1);
        }

        return extension;
    }

    private static string ExtractFileName(string path)
    {
        char dirSlash = Path.DirectorySeparatorChar;
        int slashIndex = path.LastIndexOf(dirSlash);
        string fileName = path.Substring(slashIndex + 1);

        return fileName;
    }

    private static string ExtractPath(string fullFileName)
    {
        char dirSlash = Path.DirectorySeparatorChar;
        int slashIndex = fullFileName.LastIndexOf(dirSlash);

        string path = string.Empty;

        if (slashIndex != -1)
        {
            path = fullFileName.Substring(0, slashIndex);
        }

        return path;
    }
}