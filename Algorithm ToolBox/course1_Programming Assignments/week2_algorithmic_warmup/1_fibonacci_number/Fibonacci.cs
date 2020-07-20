using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Convert.ToInt32(Console.ReadLine());
            long fib = 0;
            if (input == 0)
                fib = 0;
            else if (input == 1)
                fib = 1;
            else
                fib = Fibonacci(input);

            Console.WriteLine(fib);
        }
		private static long Fibonacci(int num)
        {
            long[] Fib = new long[num+1];
            Fib[0] = 0;
            Fib[1] = 1;
            for (int i = 2; i <= num; i++)
            {
                Fib[i] = Fib[i - 1] + Fib[i - 2];
            }
            return Fib[num];
        }
    }
}