using PisanoPeriod;
using System.Numerics;

var keepAsking = true;
do
{
    Console.WriteLine("Enter an integer to get started");
    var input = Console.ReadLine();
    Console.WriteLine();
    keepAsking = input.Length > 0;
    var periods = new List<long>();
    if(long.TryParse(input, out long modulo))
    {
        var pattern = Pisano.Fib(modulo).ToArray();
        //var j = 1;
        //var previous = 0;
        //var current = 1;
        //var temp = 0;
        //for(var i=0; i<pattern.Length; i++)
        //{
        //    temp = current;
        //    current += previous;
        //    previous = temp;
        //    Console.WriteLine($"{previous}: {pattern[i]}");
        //}
        Console.WriteLine("pattern length: " + pattern.Length);
        Console.WriteLine("________________________");
    }
} while (keepAsking);