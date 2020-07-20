using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacingParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            StringBuilder sb_input = new StringBuilder();
            StringBuilder sb_op = new StringBuilder();
            for (int k = 0; k < input.Length; k++)
            {
                if (k % 2 == 0)
                    sb_input.Append(input[k]);
                else
                    sb_op.Append(input[k]);
            }
            var maxValueOfExpression = GetMaximumValueOfExpressionDP(sb_input.ToString(), sb_op.ToString());
            Console.WriteLine(maxValueOfExpression);
        }
		 private static long GetMaximumValueOfExpressionDP(string numbers, string operators)
        {
            int len = numbers.Length;
            long[,] minValueOfExpression = new long[len + 1, len + 1];
            long[,] maxValueOfExpression = new long[len + 1, len + 1];
            // Initialize DP matrix
            for (int i = 0; i < len; i++)
            {
                minValueOfExpression[i, i] = Int32.Parse(numbers[i].ToString());
                maxValueOfExpression[i, i] = Int32.Parse(numbers[i].ToString());
            }
            for (int s = 0; s < len; s++)
            {
                for (int i = 0; i < len - s - 1; i++)
                {
                    int j = i + s + 1;
                    var minMaxValue = GetMinimumMaxValue(
                        maxValueOfExpression, minValueOfExpression, operators, i, j);
                    minValueOfExpression[i, j] = minMaxValue[0];
                    maxValueOfExpression[i, j] = minMaxValue[1];

                }
            }
            return maxValueOfExpression[0, len - 1];
        }

        private static long[] GetMinimumMaxValue(long[,] dp_maxValue, long[,] dp_minValue, string oper,
            int start, int end)
        {
            long minValue = Int32.MaxValue;
            long maxValue = Int32.MinValue;
            // calculate all possibilities i.e min-min, min-max, max-min, max-max
            for (int k = start; k < end; k++)
            {
                var a = EvaluateExpression(dp_maxValue[start, k], dp_maxValue[k + 1, end], oper[k]);
                var b = EvaluateExpression(dp_maxValue[start, k], dp_minValue[k + 1, end], oper[k]);
                var c = EvaluateExpression(dp_minValue[start, k], dp_maxValue[k + 1, end], oper[k]);
                var d = EvaluateExpression(dp_minValue[start, k], dp_minValue[k + 1, end], oper[k]);
                minValue = Math.Min(minValue, Math.Min(a, Math.Min(b,Math.Min(c,d))));
                maxValue = Math.Max(maxValue, Math.Max(a, Math.Min(b, Math.Max(c, d))));
            }
            return new long[] { minValue,maxValue};
        }
        private static long EvaluateExpression(long a, long b, char _operator)
        {
            if (_operator.ToString().Equals("+"))
            {
                return a + b;
            }
            else if (_operator.ToString().Equals("-"))
            {
                return a - b;
            }
            else if (_operator.ToString().Equals("*"))
            {
                return a * b;
            }
            else
                return 0;
        }
    }
}