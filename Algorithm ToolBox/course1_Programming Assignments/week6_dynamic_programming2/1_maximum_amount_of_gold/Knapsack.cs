using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
             var input = Console.ReadLine().Split(' ');
            var weight = Convert.ToInt32(input[0]);
            var noOfItems = Convert.ToInt32(input[1]);
            var items = Console.ReadLine().Split(' ');
            int[] itemsWeight = new int[noOfItems];
            for (int i = 0; i < noOfItems; i++)
            {
                itemsWeight[i] = Convert.ToInt32(items[i]);
            }
            var maxValue = MaxWeightKnapsackWithoutRepitionsDP(weight, itemsWeight);
            Console.WriteLine(maxValue);
        }
		private static int MaxWeightKnapsackWithoutRepitionsDP(int capacity, int[] valueOfItems)
        {
            var itemsLength = valueOfItems.Length;
            int rows = itemsLength + 1;
            int columns = capacity + 1;
            int[,] knapSack = new int[rows, columns];

            // Initialize the DP table
            for (int row = 0; row <= itemsLength; row++)
            {
                knapSack[row, 0] = 0;
            }
            for (int column = 0; column <= capacity; column++)
            {
                knapSack[0, column] = 0;
            }
            for (int itemRowValue = 1; itemRowValue <= itemsLength; itemRowValue++)
            {
                for (int weight = 1; weight <= capacity; weight++)
                {
                    if(valueOfItems[itemRowValue - 1] <= weight)
                    {
                        knapSack[itemRowValue, weight] = Math.Max(
                            valueOfItems[itemRowValue - 1] + knapSack[itemRowValue - 1, weight - valueOfItems[itemRowValue - 1]],
                            knapSack[itemRowValue - 1, weight]);
                    }
                    else
                    {
                        knapSack[itemRowValue, weight] = knapSack[itemRowValue - 1, weight];
                    }
                }
            }

            return knapSack[ itemsLength, capacity];
        }
    }
}