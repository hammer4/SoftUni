using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Fibonacci_Numbers
{
    public class Fibonacci
    {
        public List<long> numbers;

        public Fibonacci()
        {
            this.numbers = new List<long>();
        }

        public List<long> GetNumbersInRange(int startPosition, int endPosition)
        {
            return this.numbers.Skip(startPosition).Take(endPosition - startPosition).ToList();
        }
    }
}
