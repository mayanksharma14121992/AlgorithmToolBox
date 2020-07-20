using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsAndSegments
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            int totalSegments = Convert.ToInt32(input[0]);
            long[] startPoints = new long[totalSegments];
            long[] endPoints = new long[totalSegments];
            for (int i = 0; i < totalSegments; i++)
            {
                var range = Console.ReadLine().Split(' ');
                startPoints[i] = Convert.ToInt64(range[0]);
                endPoints[i] = Convert.ToInt64(range[1]);
            }
            Array.Sort(startPoints);
            Array.Sort(endPoints);
            var valuesToLookUp = Console.ReadLine().Split(' ');
            for (int i = 0; i < Convert.ToInt32(input[1]); i++)
            {
                var item = Convert.ToInt64(valuesToLookUp[i]);
                var leftElements = ModifiedBinarySearch(startPoints, item, true);
                var rightElements = ModifiedBinarySearch(endPoints, item);
                var result = leftElements + rightElements - totalSegments;
                Console.Write(result + " ");
            }
        }

		private static int ModifiedBinarySearch(long[] array, long point, bool isLeftArrayToLookUp = false)
        {
            int start = 0, end = array.Length, mid = 0;
            if (isLeftArrayToLookUp)
            {
                // Find elements left to current point to be found
                while(start < end)
                {
                    mid = (start + end) / 2;
                    if (array[mid] == point)
                    {
                        // need to check duplicates
                        while (mid + 1 < end && array[mid + 1] == point)
                            mid++;
                        break;
                    }
                    else if (array[mid] > point)
                        end = mid;
                    else
                        start = mid + 1;
                }
                while (mid > -1 && array[mid] > point)
                    mid--;
            }
            else
            {
                // Find elements right to current point to be found
                while (start < end)
                {
                    mid = (start + end) / 2;
                    if (array[mid] == point)
                    {
                        // need to check duplicates
                        while (mid > start && array[mid] == point)
                            mid--;
                        break;
                    }
                    else if (array[mid] > point)
                        end = mid;
                    else
                        start = mid + 1;
                }
                while (mid < end && array[mid] < point)
                    mid++;
            }

            if (isLeftArrayToLookUp)
                return mid + 1;
            else
                return array.Length - mid;
        }
    }
}