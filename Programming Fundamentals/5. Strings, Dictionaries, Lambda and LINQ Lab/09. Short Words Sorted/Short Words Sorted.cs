using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Short_Words_Sorted
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine().Split(new char[] { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\' ,'/', '!', '?', ' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).Where(x => x.Length<5).OrderBy(x => x).Distinct()));
        }
    }
}
