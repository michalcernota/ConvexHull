using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull.Algorithm
{
    public class GrahamScan : IConvexHullAlgorithm
    {
        public string AlgorithmName => "Graham scan";

        public List<Point> GetConvexHullPoints(IEnumerable<Point> points)
        {
            ArgumentNullException.ThrowIfNull(points);
            if (points.Count() < 3)
                throw new ArgumentException("At least 3 points are needed in order to construct a convex hull", nameof(points));

            var startingPoint = points.OrderBy(p => p.Y).ThenBy(p => p.X).First();
            var sortedPoints = GeometryHelper.OrderByPolarAngle(startingPoint, points);
            // TODO: remove collinear points by their distance due to P0

            var hull = new Stack<Point>();
            hull.Push(startingPoint);
            hull.Push(sortedPoints[1]);

            for (int i = 2; i < sortedPoints.Count; i++)
            {
                while (hull.Count >= 2 && GeometryHelper.GetOrientation(hull.ElementAt(1), hull.Peek(), sortedPoints[i]) != Orientation.CounterClockwise)
                    hull.Pop();
                hull.Push(sortedPoints[i]);
            }

            return hull.ToList();
        }
    }
}
