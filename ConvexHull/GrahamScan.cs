using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull
{
    public class GrahamScan : IConvexHullAlgorithm
    {
        public List<Point> GetConvexHullPoints(IEnumerable<Point> points)
        {
            ArgumentNullException.ThrowIfNull(points);
            if (points.Count() < 3)
                throw new ArgumentException("At least 3 points are needed in order to construct a convex hull", nameof(points));

            var startingPoint = points.OrderBy(p => p.Y).ThenBy(p => p.X).First();
            var sortedPoints = OrderByPolarAngle(startingPoint, points);
            // TODO: remove collinear points by their distance due to P0

            var hull = new Stack<Point>();
            hull.Push(startingPoint);
            hull.Push(sortedPoints[1]);

            for (int i = 2; i < sortedPoints.Count; i++)
            {
                while (hull.Count >= 2 && GetOrientation(hull.ElementAt(1), hull.Peek(), sortedPoints[i]) != Orientation.CounterClockwise)
                    hull.Pop();
                hull.Push(sortedPoints[i]);
            }

            return hull.ToList();
        }

        private static List<Point> OrderByPolarAngle(Point startingPoint, IEnumerable<Point> points)
        {
            var sortedPoints = points.OrderBy(p =>
                Math.Atan2(p.Y - startingPoint.Y, p.X - startingPoint.X)).ToList();
            return sortedPoints;
        }

        private static Orientation GetOrientation(Point p1, Point p2, Point p3)
        {
            // 2D cross-product formula
            int val = (p2.Y - p1.Y) * (p3.X - p2.X) -
                      (p2.X - p1.X) * (p3.Y - p2.Y);

            switch (val)
            {
                case 0: return Orientation.Collinear;
                case > 0: return Orientation.Clockwise;
                case < 0: return Orientation.CounterClockwise;
            }
        }
    }
}
