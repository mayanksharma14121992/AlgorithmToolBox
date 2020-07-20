using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MajorityElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var noOfItems = Convert.ToInt32(Console.ReadLine());
            var input = Console.ReadLine().Split(' ');
            var isMajorityElementPresent = IsMajorityElementPresent(input);
            Console.WriteLine(isMajorityElementPresent);
        }
		private static int IsMajorityElementPresent(string[] elements)
        {
            Dictionary<long, int> elementsLookUp = new Dictionary<long, int>();
            foreach (var item in elements)
            {
                var num = Convert.ToInt64(item);
                if (elementsLookUp.ContainsKey(num))
                    elementsLookUp[num] += 1;
                else
                    elementsLookUp.Add(num, 1);
            }
            foreach (var item in elementsLookUp)
            {
                if (item.Value > (elements.Length / 2))
                    return 1;
            }
            return 0;
        }
    }
}