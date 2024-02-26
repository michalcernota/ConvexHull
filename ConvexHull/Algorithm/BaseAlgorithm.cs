using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull.Algorithm
{
    public abstract class BaseAlgorithm
    {
        protected static void CheckInputPoints(IEnumerable<Point> points)
        {
            ArgumentNullException.ThrowIfNull(points, nameof(points));
            if (points.Count() < 3)
                throw new ArgumentException("At least 3 points are needed in order to construct a convex hull", nameof(points));
        }
    }
}
