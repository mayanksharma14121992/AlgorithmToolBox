using System;

namespace FibonacciPartialSum
{
    class Program
    {
        static void Main(string[] args)
        {
             var input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            long m = Convert.ToInt64(numbers[0]);
            long n = Convert.ToInt64(numbers[1]);
            if (n == 0 && m == 0)
            {
                Console.WriteLine(0);
                return;
            }
            var pisano = GetPisanoPeriod(10);
            // Formula : (F(n+2) - 1) - (F(m+1) - 1)  
            long lastDigitOfFibSum = 0, endLastDigit = 0, startLastDigit = 0;
            if (n == m)
            {
                lastDigitOfFibSum = Fibonacci(n % pisano, 10);
            }
            else
            {
                var start = Fibonacci((m + 1) % pisano, 10);
                startLastDigit = start != 0 ? start - 1 : 9;
                var end = Fibonacci((n + 2) % pisano, 10);
                endLastDigit = end != 0 ? end - 1 : 9;
                lastDigitOfFibSum = (endLastDigit - startLastDigit + 10) % 10;
            }
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