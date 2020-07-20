using System;

namespace fibonacci_last_digit
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Convert.ToInt32(Console.ReadLine());
            int fib = 0;
            if (input == 0)
                fib = 0;
            else if (input == 1)
                fib = 1;
            else
                fib = GetLastDigitOfFibonacci(input);

            Console.WriteLine(fib);
        }
		private static int GetLastDigitOfFibonacci(int num)
        {
            int[] Fib = new int[num+1];
            int mod = 10;
            Fib[0] = 0;
            Fib[1] = 1;
            for (int i = 2; i <= num; i++)
            {
                Fib[i] = (Fib[i - 1] + Fib[i - 2])%mod;
            }
            return Fib[num];
        }
    }
}