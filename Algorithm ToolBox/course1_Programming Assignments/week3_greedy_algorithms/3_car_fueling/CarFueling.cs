using System;

namespace CarFueling
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalDistance = Convert.ToInt32(Console.ReadLine());
            var maxDistanceForGivenFuel = Convert.ToInt32(Console.ReadLine());
            var numberOfStops = Convert.ToInt32(Console.ReadLine());
            string[] stopsArray = Console.ReadLine().Split(' ');
            int[] stops = new int[numberOfStops + 1];
            for (int i = 0; i < numberOfStops; i++)
                stops[i] = Convert.ToInt32(stopsArray[i]);

            stops[stops.Length - 1] = totalDistance;
            var getMinimumRefills = GetMinimumRefills(stops, totalDistance, maxDistanceForGivenFuel);
            Console.WriteLine(getMinimumRefills);
        }
		 private static int GetMinimumRefills(int[] stops, int totalDisance, int maxDistanceForGivenFuel)
        {
            int minReills = 0;
            if (maxDistanceForGivenFuel > totalDisance)
                return 0;
            var factor = 0;
            for (int i = 0; i < stops.Length - 1; i++)
            {
                if (stops[i + 1] - stops[i] > maxDistanceForGivenFuel)
                {
                    minReills = -1;
                    break;
                }
                if (stops[i] <= maxDistanceForGivenFuel + factor && stops[i + 1] > maxDistanceForGivenFuel + factor)
                {
                    minReills++;
                    factor = stops[i];
                }
            }
            return minReills;
        }
    }
}