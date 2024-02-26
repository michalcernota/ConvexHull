using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConvexHull.Tests
{
    public class GrahamScanTests
    {
        [Fact]
        public void GetConvexHullPoints_ThrowsArgumentNullException_IfPointsCollectionIsNull()
        {
            List<Point> points = null;
            IConvexHullAlgorithm grahamScan = new GrahamScan();
            Assert.Throws<ArgumentNullException>(() => grahamScan.GetConvexHullPoints(points));
        }

        [Fact]
        public void GetConvexHullPoints_ThrowsArgumentException_IfPointsCollectionIsUnsufficient()
        {
            var points = new List<Point>()
            {
                new Point(0,0),
                new Point(1,1)
            };

            IConvexHullAlgorithm grahamScan = new GrahamScan();
            Assert.Throws<ArgumentException>(() => grahamScan.GetConvexHullPoints(points));
        }

        [Fact]
        public void GetConvexHullPoints_ShouldReturnConvexHull()
        {
            var points = new List<Point>()
            {
                new Point(0,0),
                new Point(1,4),
                new Point(3,1),
                new Point(3,3),
                new Point(5,2),
                new Point(5,5),
                new Point(7,0),
                new Point(9,6),
            };

            IConvexHullAlgorithm grahamScan = new GrahamScan();
            var convexHull = grahamScan.GetConvexHullPoints(points);

            Assert.NotNull(convexHull);
            Assert.NotEmpty(convexHull);
            Assert.Equal(4, convexHull.Count);

            var expectedPoints = new List<Point>()
            {
                new Point(1,4),
                new Point(9,6),
                new Point(7,0),
                new Point(0,0),
            };

            Assert.True(expectedPoints.SequenceEqual(convexHull));
        }
    }
}
