using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DifferentSummands
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Convert.ToInt64(Console.ReadLine());
            var getPairwiseDistinctNumbers = GetPairwiseDistinctNumbers(input);

            var totalNumbers = getPairwiseDistinctNumbers.Count;
            Console.WriteLine(totalNumbers);
            bool isSpaceRequired = totalNumbers > 0 ? true : false;

            foreach (var item in getPairwiseDistinctNumbers)
            {
                if (!isSpaceRequired)
                    Console.Write(" ");

                Console.Write(item);
                isSpaceRequired = false;
            }
        }
		private static List<long> GetPairwiseDistinctNumbers(long num)
        {
            List<long> distinctPairwiseSum = new List<long>();
            Dictionary<long, bool> distinctNumbers = new Dictionary<long, bool>();
            if(num == 1 || num == 2)
            {
                distinctPairwiseSum.Add(num);
                return distinctPairwiseSum;
            }
            else
            {
                int counter = 1;
                var desiredSum = num;
                while (desiredSum - counter >= 0)
                {
                   if((desiredSum - counter >= 0) && (desiredSum - counter != counter) 
                        && !distinctNumbers.ContainsKey(desiredSum - counter))
                    {
                        distinctPairwiseSum.Add(counter);
                        distinctNumbers.Add(counter, true);
                        desiredSum -= counter;
                    }
                    counter += 1;
                }
            }
            return distinctPairwiseSum;
        }
    }
}