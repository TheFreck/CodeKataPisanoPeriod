using Machine.Specifications;
using System.Numerics;

namespace PisanoPeriod.Specs
{
    public class When_Building_Fibbonacci
    {
        Establish context = () =>
        {
            qty = 13;
            modulo = 8;
            expect = new Dictionary<BigInteger, BigInteger> { { 0, 1 },{ 1, 1 },{ 2, 2 },{ 3, 3 },{ 4, 5 },{ 5, 0 },{ 6, 5 },{ 7, 5 },{ 8, 2 },{ 9, 7 },{ 10, 1 },{ 11, 0 },{ 12, 1 } };
        };

        Because of = () => answer = Pisano.Fib(modulo);

        It Should_Return_The_First_N_Fibbonacci_Numbers = () =>
        {
            for (ulong i = 0; i < qty; i++)
            {
                answer[i].ShouldEqual(expect[i]);
            }
        };

        static ulong qty;
        static long modulo;
        static Dictionary<BigInteger,BigInteger> expect;
        static Dictionary<BigInteger, BigInteger> answer;
    }

    public class When_Modularizing_Fibbonacci
    {
        Establish context = () =>
        {
            modulo = 5;
            input = new BigInteger[] { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887 };
            expect = new BigInteger[] { 1, 1, 2, 3, 0, 3, 3, 1, 4, 0, 4, 4, 3, 2, 0, 2, 2, 4, 1, 0, 1, 1, 2, 3, 0, 3, 3, 1, 4, 0, 4, 4, 3, 2 };
        };

        Because of = () => answer = Pisano.Modularize(input, modulo);

        It Should_Return_The_Remainder_For_Each_Item_In_The_Array = () =>
        {
            for (var i = 0; i < answer.Length; i++)
            {
                if (answer[i] != expect[i])
                {
                    var ans = answer[i];
                    var exp = expect[i];
                    var inp = input[i];
                }
                answer[i].ShouldEqual(expect[i]);
            }
        };

        static ulong modulo;
        static BigInteger[] input;
        static BigInteger[] expect;
        static BigInteger[] answer;
    }

    public class When_Finding_The_Repeating_Pattern
    {
        Establish context = () =>
        {
            input = new BigInteger[] { 1, 2, 3, 1, 2, 3, 1, 2, 3 };
            expect = new BigInteger[] { 1, 2, 3 };
        };

        Because of = () => answer = Pisano.FindPattern(input);

        It Should_Return_An_Array_Representing_The_Base_Pattern = () =>
        {
            for (var i = 0; i < answer.Length; i++)
            {
                answer[i].ShouldEqual(expect[i]);
            }
        };

        private static BigInteger[] input;
        private static BigInteger[] expect;
        private static BigInteger[] answer;
    }

    public class When_Finding_The_Pisano_Period_Of_A_Given_Modulo
    {
        Establish context = () =>
        {
            input = 5;
            expect = 20;
        };

        Because of = () => answer = Pisano.PisanoPeriod(input);

        It Should_Return_The_Length_Of_The_Pattern = () => answer.ShouldEqual(expect);

        static int input;
        private static int expect;
        static long answer;
    }
}