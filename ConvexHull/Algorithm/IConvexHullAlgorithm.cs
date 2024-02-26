using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull.Algorithm
{
    public interface IConvexHullAlgorithm
    {
        public string AlgorithmName { get; }
        List<Point> GetConvexHullPoints(IEnumerable<Point> points);
    }
}
