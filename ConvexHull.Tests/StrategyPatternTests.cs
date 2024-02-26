using ConvexHull.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull.Tests
{
    public class StrategyPatternTests
    {
        [Fact]
        public void ConvexHullSolverCtor_ThrowsException_IfStrategyIsNotSet()
        {
            Assert.Throws<ArgumentNullException>(() => new ConvexHullSolver(null));
        }

        [Fact]
        public void SetStrategy_ThrowsException_IfStrategyIsNotSet()
        {
            var convexHullSolver = new ConvexHullSolver(new GrahamScan());
            Assert.Throws<ArgumentNullException>(() => convexHullSolver.Strategy = null);
        }

        [Fact]
        public void SetStrategy_ShouldChangeStrategyOfConvexHullDetermination()
        {
            var convexHullSolver = new ConvexHullSolver(new GrahamScan());
            Assert.Equal("Graham scan", convexHullSolver.Strategy.AlgorithmName);

            convexHullSolver.Strategy = new JarvisMarch();
            Assert.Equal("Jarvis March", convexHullSolver.Strategy.AlgorithmName);
        }
    }
}
