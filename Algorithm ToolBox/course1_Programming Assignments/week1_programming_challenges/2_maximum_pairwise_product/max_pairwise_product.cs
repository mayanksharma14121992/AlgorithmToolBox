using System;

namespace max_pairwise_products
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Convert.ToInt32(Console.ReadLine());
            var arr = Console.ReadLine();
            int[] array = new int[input];
            int outNum, i = 0;
            string[] numbers = arr.Split(' ');
            foreach (var item in numbers)
            {
                if(Int32.TryParse(item,out outNum))
                {
                    array[i++] = outNum;
                }
            }
            Console.WriteLine(GetMaxProductPair(array));
        }
		private static long GetMaxProductPair(int[] array)
        {
            int first = 0, second = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= first)
                {
                    second = first;
                    first = array[i];
                }
                else if (array[i] > second && array[i] != first)
                    second = array[i];
            }
            var res = (long)first * second;
            return res;
        }
    }
}