using FestivalManager.Core.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FestivalManager.Core.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
