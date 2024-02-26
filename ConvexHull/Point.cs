namespace ConvexHull
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Point otherPoint)
                return false;
            return otherPoint.X == X && otherPoint.Y == Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}