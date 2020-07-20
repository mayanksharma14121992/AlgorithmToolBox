using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Convert.ToInt32(Console.ReadLine());
            string[] salary = Console.ReadLine().Split(' ');
            var maxSalary = GetMaximumSalary(salary);
            Console.WriteLine(maxSalary);
        }
		 private static bool isGreter(string a, string b)
        {
            var status = Convert.ToInt32(a + b) > Convert.ToInt32(b + a) ? false : true;
            return status;
        }
		private static string GetMaximumSalary(string[] salary)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < salary.Length; i++)
            {
                var max = salary[i];
                for (int j = i + 1; j < salary.Length; j++)
                {
                   if(isGreter(max, salary[j]))
                    {
                        max = salary[j];
                        salary[j] = salary[i];
                        salary[i] = max;
                    }
                }
                stringBuilder.Append(max);
            }
            return stringBuilder.ToString();
        }
    }
}