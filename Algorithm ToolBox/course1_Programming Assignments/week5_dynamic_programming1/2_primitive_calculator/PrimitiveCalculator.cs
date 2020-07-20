using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = Convert.ToInt32(Console.ReadLine());
            var lookUpTable = new int[number + 1];
            ConstructLookUpTable(lookUpTable, number);
            var getMinmumOps = GetMinimumOpertaionToObtainNumberDP(lookUpTable, number);
            Console.WriteLine(getMinmumOps.Count - 1);
            foreach (var item in getMinmumOps)
            {
                Console.Write(item + " ");
            }
        }
		 private static void InitializeArray(int[] array, int num)
        {
            for (int i = 1; i <= num; i++)
            {
                array[i] = Int32.MaxValue;
            }
        }
        private static void ConstructLookUpTable(int[] array, int num)
        {
            InitializeArray(array, num);
            array[0] = 0;
            array[1] = 0;
            for (int i = 2; i <= num; i++)
            {
                if (1 + array[i - 1] < array[i])
                    array[i] = 1 + array[i - 1];

                if (i % 2 == 0 && 1 + array[i / 2] < array[i])
                    array[i] = 1 + array[i / 2];

                if (i % 3 == 0 && 1 + array[i / 3] < array[i])
                    array[i] = 1 + array[i / 3];
            }
        }
        private static List<int> GetMinimumOpertaionToObtainNumberDP(int[] lookUpTable ,int number)
        {
             List<int> primitiveCalculator = new List<int>();
            //primitiveCalculator.Add(number);
            //while(number > 1)
            //{
            //    var nextElement = Int32.MaxValue;
            //    if(number % 3 == 0)
            //    {
            //        if (number % 2 == 0)
            //        {
            //            if (lookUpTable[number / 3] < lookUpTable[number / 3])
            //            {
            //                nextElement = number / 3;
            //                number /= 3;
            //            }
            //            else
            //            {
            //                nextElement = number / 2;
            //                number /= 2;
            //            }
            //        }
            //        else
            //        {
            //            nextElement = number / 3;
            //            number /= 3;
            //        }
            //        primitiveCalculator.Add(nextElement);
            //    }
            //    else if(number % 2 == 0)
            //    {
            //        if((number - 1) % 3 == 0)
            //        {
            //            if(lookUpTable[(number - 1)/3] < lookUpTable[number/2])
            //            {
            //                nextElement = number - 1;
            //                number -= 1;
            //            }
            //            else
            //            {
            //                nextElement = number / 2;
            //                number /= 2;
            //            }
            //            primitiveCalculator.Add(nextElement);
            //        }
            //    }
            //    else
            //    {
            //        nextElement = number - 1;
            //        number -= 1;
            //        primitiveCalculator.Add(nextElement);
            //    }
            //}
            for (int nextElement = number; nextElement > 1;)
            {
                primitiveCalculator.Add(nextElement);
                if (lookUpTable[nextElement - 1] == lookUpTable[nextElement] - 1)
                    nextElement -= 1;
                else if (nextElement % 2 == 0 && lookUpTable[nextElement / 2] == lookUpTable[nextElement] - 1)
                    nextElement /= 2;
                else if (nextElement % 3 == 0 && lookUpTable[nextElement / 3] == lookUpTable[nextElement] - 1)
                    nextElement /= 3;
            }
            primitiveCalculator.Add(1);
            primitiveCalculator.Reverse();
            return primitiveCalculator;
        }
    }
}