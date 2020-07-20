using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveringSegments
{
    class Program
    {
        static void Main(string[] args)
        {
             var input = Convert.ToInt32(Console.ReadLine());
            List<CollectingSignatures> collectingSignaturesList = new List<CollectingSignatures>();
            for (int i = 0; i < input; i++)
            {
                string[] points = Console.ReadLine().Split(' ');
                var pointA = Convert.ToInt32(points[0]);
                var pointB = Convert.ToInt32(points[1]);
                collectingSignaturesList.Add(new CollectingSignatures(pointA, pointB));
            }
            CollectingSignatures collectingSignatures = new CollectingSignatures();
            var getMinPointsForGivenSegments = collectingSignatures.GetMinPointsForGivenSegments(collectingSignaturesList);
            var totalPoints = getMinPointsForGivenSegments.Count;
            Console.WriteLine(totalPoints);
            bool isSpaceRequired = totalPoints > 0 ? true : false;

            foreach (var item in getMinPointsForGivenSegments)
            {
                if(!isSpaceRequired)
                    Console.Write(" ");

                Console.Write(item);
                isSpaceRequired = false;
            }
        }
    }
	 public class CollectingSignatures
    {
        public int RangeStartPoint { get; set; }
        public int RangeEndPoint { get; set; }
        public CollectingSignatures()
        {

        }
        public CollectingSignatures(int raneStartPoint, int rangeEndPoint)
        {
            RangeStartPoint = raneStartPoint;
            RangeEndPoint = rangeEndPoint;
        }

        public List<int> GetMinPointsForGivenSegments(List<CollectingSignatures> collectingSignaturesList )
        {
            List<int> minPoints = new List<int>();

            var sortedCollectingSignaturesList = collectingSignaturesList.OrderBy(x => x.RangeEndPoint).ToList();
            int start = 0;
            while(start < sortedCollectingSignaturesList.Count)
            {
                var rangeEndPoint = sortedCollectingSignaturesList[start].RangeEndPoint;
                minPoints.Add(rangeEndPoint);
                start += 1;
                while (start < sortedCollectingSignaturesList.Count && 
                    rangeEndPoint >= sortedCollectingSignaturesList[start].RangeStartPoint)
                {
                    start += 1;
                }
            }
            return minPoints;
        }
    }
}