namespace ConvexHull
{
    internal static class GeometryHelper
    {

        public static Orientation GetOrientation(Point p1, Point p2, Point p3)
        {
            // 2D cross-product formula
            int val = (p2.Y - p1.Y) * (p3.X - p2.X) -
                      (p2.X - p1.X) * (p3.Y - p2.Y);

            switch (val)
            {
                case 0: return Orientation.Collinear;
                case > 0: return Orientation.Clockwise;
                case < 0: return Orientation.CounterClockwise;
            }
        }

        public static List<Point> OrderByPolarAngle(Point startingPoint, IEnumerable<Point> points)
        {
            var sortedPoints = points.OrderBy(p =>
                Math.Atan2(p.Y - startingPoint.Y, p.X - startingPoint.X)).ToList();
            return sortedPoints;
        }
    }
}