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
            return Fib(n).LongCount();
        }

        public static IEnumerable<BigInteger> Fib(long n)
        {
            if (n <= 1) return new List<BigInteger>();
            var fibMods = new Dictionary<BigInteger,BigInteger>();
            var pattern = new Dictionary<BigInteger,BigInteger>();
            BigInteger fibsIndex = 2;
            BigInteger patternIndex = 2;
            bool buildingPattern = true;
            bool testingPattern;
            fibMods.Add(0, 1);
            fibMods.Add(1, 1);
            pattern.Add(0, 1);
            pattern.Add(1, 1);
            do
            {
                do
                {
                    if(fibMods.Count > 3){
                        if( fibMods[fibMods.Count - 1] == fibMods[2] && fibMods[fibMods.Count - 2] == fibMods[1] && fibMods[fibMods.Count - 3] == fibMods[0])
                        {
                            buildingPattern = false;
                            break;
                        }
                    }
                    pattern.Add(patternIndex++, (fibMods[fibsIndex - 2] + fibMods[fibsIndex - 1]) % n);
                    var itemToAdd = (fibMods[fibsIndex - 2] + fibMods[fibsIndex - 1])% n;
                    fibMods.Add(fibsIndex++, itemToAdd);
                } while (buildingPattern);

                for(var i=0; i<=(pattern.Count-3)*3; i++)
                {
                    if (fibMods[i % fibMods.Count] != pattern[i % pattern.Count])
                    {
                        break;
                    }
                }
                testingPattern = false;
            } while (testingPattern);

            return pattern.Values.Take((pattern.Count - 3));
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
