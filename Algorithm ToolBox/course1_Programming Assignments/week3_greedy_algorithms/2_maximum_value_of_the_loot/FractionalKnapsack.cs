using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionalKnapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            var num = Convert.ToInt32(numbers[0]);
            var weight = Convert.ToInt32(numbers[1]);
            List<FunctionalKnapsack> itemsList = new List<FunctionalKnapsack>();
            for (int i = 0; i < num; i++)
            {
               var itemValueAndWeight = Console.ReadLine().Split(' ');
               var itemValue = Convert.ToInt32(itemValueAndWeight[0]);
               var itemWeight = Convert.ToInt32(itemValueAndWeight[1]);
               var item = new FunctionalKnapsack(itemValue, itemWeight);
               itemsList.Add(item);
            }
            FunctionalKnapsack functionalKnapsack = new FunctionalKnapsack();
            var getMaxValueOfItems = functionalKnapsack.GetMaximumValueForWeight(weight, itemsList);
            Console.WriteLine($"{getMaxValueOfItems:0.0000}");
        }
    }
	public class FunctionalKnapsack
    {
        public int ItemValue { get; set; }
        public int ItemWeight { get; set; }
        public double ItemWeightPerUnit { get; set; }

        public FunctionalKnapsack()
        {
                
        }
        public FunctionalKnapsack(int itemValue, int itemWeight )
        {
            ItemValue = itemValue;
            ItemWeight = itemWeight;
            ItemWeightPerUnit = (double)itemValue / itemWeight;
        }

        public double GetMaximumValueForWeight(int weight, List<FunctionalKnapsack> itemsList)
        {
            var sortedItemList = itemsList.OrderByDescending(i => i.ItemWeightPerUnit).ToList();
            double maxValueOfItems = 0;
            foreach (var item in sortedItemList)
            {
                if(item.ItemWeight <= weight)
                {
                    maxValueOfItems += item.ItemValue;
                    if (item.ItemWeight - weight == 0)
                        break;
                    weight -= item.ItemWeight;
                }
                else
                {
                    maxValueOfItems += weight * item.ItemWeightPerUnit;
                    break;
                }
            }
            return maxValueOfItems;
        }
    }
}