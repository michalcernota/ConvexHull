using ConvexHull.Algorithm;
using ConvexHull.Tests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull.Tests
{
    public class JarvisMarchTests
    {
        [Theory]
        [ClassData(typeof(GrahamScanTestData))]
        public void GetConvexHullPoints_ShouldReturnConvexHull(List<Point> points, List<Point> expected)
        {
            var convexHullSolver = new ConvexHullSolver(new JarvisMarch());
            var convexHull = convexHullSolver.Solve(points);

            Assert.NotNull(convexHull);
            Assert.NotEmpty(convexHull);
            Assert.Equal(expected.Count, convexHull.Count);

            // Order of convex hull elements differes by algorithm use, so I can not
            // use SequenceEqual in this case
            foreach (var item in convexHull)            
                Assert.Contains(item, expected);
        }
    }
}
