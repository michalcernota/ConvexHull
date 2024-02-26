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
    }
}
