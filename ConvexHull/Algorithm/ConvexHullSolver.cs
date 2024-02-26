using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull.Algorithm
{
    public class ConvexHullSolver
    {
        private IConvexHullAlgorithm _solvingStrategy;

        public IConvexHullAlgorithm Strategy
        {
            get
            {
                return _solvingStrategy;
            }

            set
            {
                ArgumentNullException.ThrowIfNull(value, nameof(value));
                _solvingStrategy = value;
            }
        }

        public ConvexHullSolver(IConvexHullAlgorithm strategy)
        {
            Strategy = strategy;
        }

        public List<Point> Solve(List<Point> points)
        {
            return _solvingStrategy.GetConvexHullPoints(points);
        }
    }
}
