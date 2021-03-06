using System;

namespace GCD
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            long n = Convert.ToInt64(numbers[0]);
            long m = Convert.ToInt64(numbers[1]);
            long gcd = 1;
            if(n > m)
                gcd = FindGcd(n, m);
            else
                gcd = FindGcd(m, n);

            Console.WriteLine(gcd);
        }
		private static long FindGcd(long a, long b)
        {
            if (b == 0)
                return a;
            else return FindGcd(b,a % b);
        }
    }
}