using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull.Algorithm
{
    public class JarvisMarch : IConvexHullAlgorithm
    {
        public string AlgorithmName => "Jarvis March";

        public List<Point> GetConvexHullPoints(IEnumerable<Point> points)
        {
            throw new NotImplementedException();
        }
    }
}
