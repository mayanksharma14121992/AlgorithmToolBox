using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Closest
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = Convert.ToInt32(Console.ReadLine());
            ClosestPairOfPointsInPlane pointObject = new ClosestPairOfPointsInPlane();
            List<ClosestPairOfPointsInPlane> pointsList = new List<ClosestPairOfPointsInPlane>();
            for (int i = 0; i < input; i++)
            {
                var point = Console.ReadLine().Split(' ');
                pointsList.Add(new ClosestPairOfPointsInPlane(Convert.ToInt64(point[0]),Convert.ToInt64(point[1])));
            }
            var minDistance = pointObject.GetClosestPoints(pointsList,pointsList.Count);
            Console.WriteLine($"{minDistance:0.0000}");
        }
    }
	 public class ClosestPairOfPointsInPlane
    {
        public long XCoordinate { get; set; }
        public long YCoordinate { get; set; }

        public ClosestPairOfPointsInPlane()
        {

        }

        public ClosestPairOfPointsInPlane(long xCoordinate, long yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public double GetClosestPoints(List<ClosestPairOfPointsInPlane> pointsList, int listCount)
        {
            var sortedListByX = GetSortedList(pointsList, true);
            var sortedListByY = GetSortedList(pointsList);
            return GetMinimumDistanceMoreOptimized(sortedListByX, sortedListByY, listCount);
            //return GetMinimumDistanceOptimized(sortedListByX,listCount);
        }

        private List<ClosestPairOfPointsInPlane> GetSortedList(List<ClosestPairOfPointsInPlane> pointsList,
            bool sortedByXAxis = false)
        {
            List<ClosestPairOfPointsInPlane> sortedList = new List<ClosestPairOfPointsInPlane>();
            if(sortedByXAxis)
                sortedList = pointsList.OrderBy(x => x.XCoordinate).ToList();
            else
                sortedList = pointsList.OrderBy(y => y.YCoordinate).ToList();
            return sortedList;
        }

        private double GetMinimumDistanceOptimized(List<ClosestPairOfPointsInPlane> pointsList, int listSize)
        {
            double minDistance = Int32.MaxValue;
            int stripElementsCount = 0;

            if (listSize <= 3)
                return GetMinimumDistance(pointsList, listSize);
            else
            {
                int mid = listSize / 2;
                var midPoint = pointsList[mid];
                // Recurse for two sub points range
                double distanceLeft = GetMinimumDistanceOptimized(pointsList, mid);
                double distanceRight = GetMinimumDistanceOptimized(pointsList.Skip(mid).ToList(), listSize - mid);

                minDistance = GetMinimum(distanceLeft, distanceRight);
                if (minDistance == 0)
                    return 0;
                // build points list upto minumum distance 
                // by creating hypothetical vertical strip
                List<ClosestPairOfPointsInPlane> strip = new List<ClosestPairOfPointsInPlane>();
                for (int i = 0; i < listSize; i++)
                {
                  if((pointsList[i].XCoordinate - midPoint.XCoordinate) <= minDistance)
                  {
                        strip.Add(pointsList[i]);
                        stripElementsCount++;
                  }
                }
            }
            var getStripClosest = GetStripClosest(pointsList, stripElementsCount, minDistance);
            return GetMinimum(minDistance, getStripClosest);
        }

        private double GetMinimumDistanceMoreOptimized(List<ClosestPairOfPointsInPlane> arrayX,
            List<ClosestPairOfPointsInPlane> arrayY, int listSize)
        {
            
            int stripElementsCount = 0;

            if (listSize <= 3)
                return GetMinimumDistance(arrayX, listSize);
           
            int mid = listSize / 2;
            var midPoint = arrayX[mid];

            var leftArrayY = new List<ClosestPairOfPointsInPlane>();
            var rightArrayY = new List<ClosestPairOfPointsInPlane>();

            int leftIdx = 0, rightIdx = 0;
            for (int i = 0; i < listSize; i++)
            {
                if (arrayY[i].XCoordinate <= midPoint.XCoordinate && leftIdx < mid)
                {
                    leftArrayY.Add(arrayY[i]);
                    leftIdx++;
                }
                else
                {
                    rightArrayY.Add(arrayY[i]);
                    rightIdx++;
                }
                    
            }

            double dist_1 = GetMinimumDistanceMoreOptimized(arrayX, leftArrayY, mid);
            double dist_2 = GetMinimumDistanceMoreOptimized(arrayX.Skip(mid).ToList(), rightArrayY, listSize - mid);

            double minDistance = GetMinimum(dist_1,dist_2);

            var strip = new List<ClosestPairOfPointsInPlane>();
            for (int i = 0; i < listSize; i++)
            {
                if(Math.Abs(arrayY[i].XCoordinate - midPoint.XCoordinate) < minDistance)
                {
                    strip.Add(arrayY[i]);
                    stripElementsCount++;
                }
            }
            return GetStripClosest(strip, stripElementsCount, minDistance);
        }

        private double GetStripClosest(List<ClosestPairOfPointsInPlane> pointsList, int listSize,  double distance)
        {
            double minDistance = distance;
            var sortedList = GetSortedList(pointsList);
            for (int i = 0; i < listSize; i++)
            {
                // this inner loop should run at most 7 times
                // thus complexity is not O(n*n) but it will be O(n)
                for (int j = i + 1; j < listSize && (sortedList[j].YCoordinate - sortedList[i].YCoordinate <= distance); j++)
                {
                    var pointsDistance = GetDistance(sortedList[i], sortedList[j]);
                    minDistance = GetMinimum(pointsDistance, minDistance);
                }
            }
            return minDistance;
        }

        private double GetMinimumDistance(List<ClosestPairOfPointsInPlane> pointsList,int listSize)
        {
            double minDistance = Int32.MaxValue;
            for (int i = 0; i < listSize - 1; i++)
            {
                for (int j = i + 1; j < listSize; j++)
                {
                    var distance = GetDistance(pointsList[i], pointsList[j]);
                    minDistance = GetMinimum(distance, minDistance);
                }
            }
            return minDistance;
        }

        private double GetDistance(ClosestPairOfPointsInPlane point1, ClosestPairOfPointsInPlane point2)
        {
            var x = point2.XCoordinate - point1.XCoordinate;
            var y = point2.YCoordinate - point1.YCoordinate;

            var distance = Math.Sqrt(x * x + y * y);
            return distance;
        }

        private double GetMinimum(double a, double b)
        {
            return a > b ? b : a;
        }
    }
}