using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PisanoPeriod
{
    public class Pisano
    {
        public static long PisanoPeriod(long n)
        {
            var fibs = Fib(500);
            var modularized = Modularize(fibs, (ulong)n);
            var pattern = FindPattern(modularized);

            return pattern.LongLength;
        }

        public static ulong[] Fib(long qty)
        {
            var fibs = new ulong[qty];
            fibs[0] = 1;
            fibs[1] = 1;
            for (int i = 2; i < qty; i++)
            {
                fibs[i] = fibs[i - 2] + fibs[i - 1];
            }

            return fibs;
        }

        public static ulong[] FindPattern(ulong[] input)
        {
            var stringInput = string.Join(",", input);
            // look for a pattern of 2
            // look for a pattern of 3

            var pattern = new List<ulong>();
            for (var i = 2; i < input.Length; i++)
            {
                pattern = input.Take(i).ToList();
                var patternMatch = true;
                for (var j = 0; j < input.Length; j += i)
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
                if (patternMatch)
                    return pattern.ToArray();

            }

            return pattern.ToArray();
        }

        public static ulong[] Modularize(ulong[] input, ulong modulo)
        {
            return input.Select(i => i % modulo).ToArray();
        }
    }
}
