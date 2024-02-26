namespace ConvexHull.Tests
{
    public class PointTests
    {
        [Fact]
        public void PointCtor_ShouldSetCoordinates()
        {
            var point = new Point(1, 2);
            Assert.Equal(1, point.X);
            Assert.Equal(2, point.Y);
        }

        [Fact]
        public void ToString_ShouldReturnCoordinatesInBrackets()
        {
            var point = new Point(3, 4);
            Assert.Equal("(3,4)", point.ToString());
        }
    }
}