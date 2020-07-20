using System;

namespace DotProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Convert.ToInt32(Console.ReadLine());
            string[] profit = Console.ReadLine().Split(' ');
            string[] avgClick = Console.ReadLine().Split(' ');
            long[] profitPerClick = new long[input];
            long[] averageClicks = new long[input];
            for (int i = 0; i < input; i++)
            {
                profitPerClick[i] = Convert.ToInt64(profit[i]);
                averageClicks[i] = Convert.ToInt64(avgClick[i]);
            }
            var getMaxRevenue = MaximumRevenue(profitPerClick, averageClicks);
            Console.WriteLine(getMaxRevenue);
        }
		 private static long MaximumRevenue(long[] profitPerClick, long[] averageClicks)
        {
            long maxRevenue = 0;
            Array.Sort(profitPerClick);
            Array.Sort(averageClicks);
            for (int i = 0; i < profitPerClick.Length; i++)
            {
                maxRevenue += (profitPerClick[i] * averageClicks[i]);
            }
            return maxRevenue;
        }
    }
}