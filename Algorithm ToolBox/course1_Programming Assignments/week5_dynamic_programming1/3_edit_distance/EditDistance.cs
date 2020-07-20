using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            var string1 = Console.ReadLine();
            var string2 = Console.ReadLine();
            var editDistance = CalculateEditDistance(string1, string2);
            Console.WriteLine(editDistance);
        }
		 private static int CalculateEditDistance(string str1, string str2)
        {
            var len1 = str1.Length;
            var len2 = str2.Length;
            int[,] editDiatance = new int[len1+1,len2+1];
            // Initialize the first column as row number as we are comparing
            // the indices of first string with empty string 
            for (int row = 0; row <= len1; row++)
            {
                editDiatance[row, 0] = row;
            }
            // Initialize the first row as row number as we are comparing
            // the indices of first string with empty string 
            for (int column = 0; column <= len2; column++)
            {
                editDiatance[0, column] = column;
            }
            // Fill the remaining DP table column wise
            for (int column = 1; column <= len2; column++)
            {
                for (int row = 1; row <= len1; row++)
                {
                  if(str1[row-1].Equals(str2[column-1]))
                    {
                        editDiatance[row, column] = Math.Min(Math.Min(editDiatance[row-1, column-1], editDiatance[row-1, column] + 1),
                            editDiatance[row, column-1] + 1);
                    }
                  else
                    {
                        editDiatance[row, column] = Math.Min(Math.Min(editDiatance[row - 1, column - 1] + 1, editDiatance[row - 1, column] + 1),
                            editDiatance[row, column - 1] + 1);
                    }
                }
            }

            return editDiatance[len1,len2];
        }
    }
}