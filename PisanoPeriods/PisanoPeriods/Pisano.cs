using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PisanoPeriod
{
    public class Pisano
    {
        public static long PisanoPeriod(long n)
        {
            var fibs = Fib(100*(ulong)n,n);
            var pattern = FindPattern(fibs);
            return pattern.LongLength;
        }

        public static BigInteger[] Fib(ulong qty,long modulo)
        {
            var fibs = new BigInteger[qty];
            fibs[0] = 1;
            fibs[1] = 1;
            for (ulong i = 2; i < qty; i++)
            {
                fibs[i] = (fibs[i - 2] + fibs[i - 1])%modulo;
            }

            return fibs;
        }

        public static BigInteger[] FindPattern(BigInteger[] input)
        {
            var pattern = new List<BigInteger>();
            for (var i = 2; i < input.Length; i++)
            {
                pattern = input.Take(i).ToList();
                var patternMatch = true;
                for (var j = 0; j < input.Length; j += i)
                {
                    if (j+pattern.Count <= input.Length)
                    {
                        for (var k = 0; k < i && j + k < input.Length; k++)
                        {
                            if (input[j + k] != pattern[k])
                            {
                                patternMatch = false;
                                break;
                            }
                        }
                    }
                }
                if (patternMatch)
                    return pattern.ToArray();
            }

            return pattern.ToArray();
        }

        public static BigInteger[] Modularize(BigInteger[] input, BigInteger modulo)
        {
            return input.Select(i => i % modulo).ToArray();
        }
    }
}
