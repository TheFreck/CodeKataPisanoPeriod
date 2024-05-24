using PisanoPeriod;

var keepAsking = true;
do
{
    Console.WriteLine("Enter an integer to get started");
    var input = Console.ReadLine();
    keepAsking = input.Length > 0;
    var periods = new List<long>();
    if(long.TryParse(input, out long modulo))
    {
        //for(var i=2; i<=modulo; i++)
        //{
        //    periods.Add(Pisano.PisanoPeriod(i));
        //}
        //Console.WriteLine("Pisano Period Counts");
        //for(var i=0; i<periods.Count; i++)
        //{
        //    Console.WriteLine($"{i+2}: {periods[i]}");
        //}
        Pisano.PisanoPeriod(modulo);
    }
} while (keepAsking);