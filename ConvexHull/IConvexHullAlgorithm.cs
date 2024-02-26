using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull
{
    public interface IConvexHullAlgorithm
    {
        List<Point> GetConvexHullPoints(IEnumerable<Point> points);
    }
}
