using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvexHull.Tests.Data
{
    public class GrahamScanTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<Point>()
                {
                    new Point(0,0),
                    new Point(1,4),
                    new Point(3,1),
                    new Point(3,3),
                    new Point(5,2),
                    new Point(5,5),
                    new Point(7,0),
                    new Point(9,6)
                },
                new List<Point>()
                {
                    new Point(1,4),
                    new Point(9,6),
                    new Point(7,0),
                    new Point(0,0)
                }
            };
            yield return new object[]
            {
                new List<Point>()
                {
                    new Point(0,3),
                    new Point(1,1),
                    new Point(2,2),
                    new Point(4,4),
                    new Point(0,0),
                    new Point(1,2),
                    new Point(3,1),
                    new Point(3,3)
                },
                new List<Point>()
                {
                    new Point(0,3),
                    new Point(4,4),
                    new Point(3,1),
                    new Point(0,0)
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
