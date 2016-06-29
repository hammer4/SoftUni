using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Prime_Checker
{
    public class Number
    {
        public long value;
        public bool isPrime;

        public Number(long value, bool isPrime)
        {
            this.value = value;
            this.isPrime = isPrime;
        }

        public long GetNextPrime()
        {
            long nextNumber = this.value + 1;

            while (true)
            {
                bool isPrime = true;
                if (this.value == 0 || this.value == 1)
                {
                    return this.value + 1;
                }
                else
                {
                    for(int i = 2; i<=Math.Sqrt(nextNumber); i++)
                    {
                        if(nextNumber % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if(isPrime)
                    {
                        return nextNumber;
                    }
                }

                nextNumber++;
            }
        }
    }
}
