using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
		private static Random random = new Random();
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            var input = Console.ReadLine().Split(' ');
            long[] inputArray = new long[n];
            for (int i = 0; i < input.Length; i++)
            {
                inputArray[i] = Convert.ToInt64(input[i]);
            }
            RandomizedQuickSort(inputArray, 0, n - 1);
            for (int i = 0; i < n; i++)
            {
                Console.Write(inputArray[i] + " ");
            }
        }
		private static void RandomizedQuickSort(long[] array, int left, int right)
        {
            if (left >= right)
                return;
            int randomElementIndex = random.Next(right - left + 1) + left;
            SwapElements(ref array[left], ref array[randomElementIndex]);
            //use partition3
            int[] partitionIndex = Partition3(array, left, right);
            RandomizedQuickSort(array, left, partitionIndex[0] - 1);
            RandomizedQuickSort(array, partitionIndex[1] + 1, right);
        }
        private static int[] Partition3(long[] array, int left, int right)
        {
            int indexOfRandomElement = left, repet = 0, j = left, m2 = right;
            long randomElement = array[left];

            for (int i = left + 1; i <= right; i++)
            {
                if (array[i] <= randomElement)
                {
                    j++;
                    if (array[i] == randomElement)
                    {
                        repet++;
                    }
                    SwapElements(ref array[i], ref array[j]);
                    if(array[j] < randomElement)
                    {
                        SwapElements(ref array[left], ref array[j]);
                        left++;
                    }
                }
            }
            SwapElements(ref array[left], ref array[j]);

            m2 = j;
            int[] m = { j - repet, m2 };
            return m;
        }
		private static void SwapElements(ref long num1, ref long num2)
        {
            long temp = num1;
            num1 = num2;
            num2 = temp;
        }
    }
}