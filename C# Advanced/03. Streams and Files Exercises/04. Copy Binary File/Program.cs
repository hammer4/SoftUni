using System;
using System.IO;

namespace _04._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "../Resources/copyMe.png";
            string outputPath = "../Output/04/image.png";

            using(FileStream source = new FileStream(inputPath, FileMode.Open))
            {
                using(FileStream destination = new FileStream(outputPath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    int readBytes;
                    while((readBytes = source.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
