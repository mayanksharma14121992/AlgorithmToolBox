using System;

namespace FibonacciSumLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Convert.ToInt64(Console.ReadLine());
            if(input == 0)
            {
                Console.WriteLine(0);
                return;
            }
            var pisano = GetPisanoPeriod(10);
            // Formula : F(n+2) - F(2)
            var lastDigit = Fibonacci((input + 2) % pisano, 10);
            var lastDigitOfFibSum = lastDigit != 0 ? lastDigit - 1 : 9;
            Console.WriteLine(lastDigitOfFibSum);
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
                Fib[i] = (Fib[i - 1] + Fib[i - 2])%modulo;
            }
            return Fib[num];
        }
    }
}