using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inversions
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = Convert.ToInt32(Console.ReadLine());
            var input = Console.ReadLine().Split(' ');

            long[] array = new long[num];
            long[] auxillaryArray = new long[num];
            for (int i = 0; i < num; i++)
            {
                array[i] = Convert.ToInt64(input[i]);
            }
            var noOfInversions = CountInversions(array, auxillaryArray, 0, array.Length - 1);
            Console.WriteLine(noOfInversions);
        }
		private static int CountInversions(long[] array, long[] auxillary, int start, int end) 
        {
            int mid;
            int noOfInversions = 0;
            if(end > start)
            {
                mid = (end + start) / 2;
                noOfInversions += CountInversions(array, auxillary, start, mid);
                noOfInversions += CountInversions(array, auxillary, mid + 1, end);
                noOfInversions += Merge(array, auxillary, start, mid+1, end);
            }
            return noOfInversions;
        }
		private static int Merge(long[] array, long[] auxillary, int start, int mid, int end)
        {
            int inversions = 0;

            int leftSubArray_Index = start;
            int rightSubArray_Index = mid;
            int resultArray_Index = start;
            while(leftSubArray_Index <= mid - 1 && rightSubArray_Index <= end )
            {
                if (array[leftSubArray_Index] <= array[rightSubArray_Index])
                    auxillary[resultArray_Index++] = array[leftSubArray_Index++];
                else
                {
                    auxillary[resultArray_Index++] = array[rightSubArray_Index++];
                    // since array is sorted 
                    // so if any inversion occurs at i
                    // the elements from i+1 to mid will also encounter this inversion
                    inversions = inversions + (mid - leftSubArray_Index);
                }
            }
            while(leftSubArray_Index <= mid - 1)
                auxillary[resultArray_Index++] = array[leftSubArray_Index++];

            while (rightSubArray_Index <= end)
                auxillary[resultArray_Index++] = array[rightSubArray_Index++];

            // copy the auxillary array items to original 
            // to get the sorted array
            for (int i  = start; i <= end; i++)
                array[i] = auxillary[i];

            return inversions;
        }
    }
}