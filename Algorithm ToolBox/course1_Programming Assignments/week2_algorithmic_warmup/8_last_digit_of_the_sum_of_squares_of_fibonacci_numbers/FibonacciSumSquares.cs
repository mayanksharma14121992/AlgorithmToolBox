using System;

namespace FibonacciSumSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Convert.ToInt64(Console.ReadLine());
            var pisano = GetPisanoPeriod(10);
            var endFibSquareDigit = (Fibonacci((input) % pisano, 10) * Fibonacci((input + 1) % pisano, 10)) % 10;
            Console.WriteLine(endFibSquareDigit);
        }
		private static long GetPisanoPeriod(long n)
        {
            if (n == 1)
                return 1;
            long pisano = 0, prev = 0,curr = 1, next = 1;
            for (long i = 0; i < n * n; i++)
            {
                next = (prev + curr) % n;
                prev = curr;
                curr = next;
                if(prev == 0 && curr == 1)
                {
                    pisano = i + 1;
                    break;
                }
            }
            return pisano;
        }
		private static long Fibonacci(long num, long modulo)
        {
            if (num == 0)
                return 0;
            if (num == 1)
                return 1;
            long[] Fib = new long[num + 1];
            Fib[0] = 0;
            Fib[1] = 1;
            for (long i = 2; i <= num; i++)
            {
                Fib[i] = (Fib[i - 1] + Fib[i - 2]) % modulo;
            }
            return Fib[num];
        }
    }
}