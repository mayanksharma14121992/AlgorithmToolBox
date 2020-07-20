using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var testCases = Console.ReadLine().Split(' ');
            long[] sortedArray = new long[input.Length - 1];
            for (int i = 1; i < input.Length; i++)
            {
                sortedArray[i - 1] = Convert.ToInt64(input[i]);
            }
            for (int i = 1; i < testCases.Length; i++)
            {
                var num = Convert.ToInt64(testCases[i]);
                var isElementIndexFound = BinarySerach(sortedArray, 0, input.Length - 2, num);
                Console.Write(isElementIndexFound + " ");
            }
        }
		private static int BinarySerach(long[] sortedArray, int start, int end, long num)
        {
            if (end - start > 0)
            {
                if (sortedArray[start] == num)
                    return start;
                if (sortedArray[end] == num)
                    return end;
                double index = start + (end - start) / 2;
                var mid = Convert.ToInt32(Math.Ceiling(index));
                if (sortedArray[mid] == num)
                    return mid;
                else if (sortedArray[mid] < num)
                    return BinarySerach(sortedArray, mid + 1, end, num);
                else
                    return BinarySerach(sortedArray, start, mid - 1, num);
            }
            return -1;
        }
    }
}