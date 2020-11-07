using OpenTK.Graphics.ES20;
using System.Drawing;
using System.Numerics;
using Xunit;

namespace BMX.Tests
{
    public class VectorExtensionsTest
    {
        [Theory]
        // 90 degree angles
        [InlineData(100, 110, 0.0, 100, 110)]
        [InlineData(100,110,90.0,90,100)]
        [InlineData(100, 110, 180.0, 100, 90)]
        [InlineData(100, 110, 270.0, 110, 100)]

        // 45 degree angles
        [InlineData(100, 110, 45.0, 92, 107)]
        [InlineData(100, 110, 135.0, 92, 92)]
        [InlineData(100, 110, 225.0, 107, 92)]
        [InlineData(100, 110, 315.0, 107, 107)]
        public void CanRotateAroundGivenPointCorrectly(int pointX, int pointY, float angle, int expectedX, int expectedY)
        {
            // Arrange
            var point = new Vector2(pointX, pointY);
            var rotationPoint = new Vector2(100, 100);
            var expectedResult = new Vector2(expectedX, expectedY);

            // Act
            var result = point.RotateAbout(rotationPoint, angle);

            Assert.Equal(expectedResult, result);

        }

        [Theory]
        // 90 degree angles
        [InlineData(110,100,0)]
        [InlineData(100, 110, 90)]
        [InlineData(90, 100, 180)]
        [InlineData(100, 90, 270)]
        public void CanCalculateBearingCorrectly(int pointX, int pointY, float expectedResult)
        {
            // Arrange
            var point = new Vector2(pointX, pointY);
            var targetPoint = new Vector2(100, 100);

            // Act
            var result = point.BearingTo(targetPoint);

            Assert.Equal(expectedResult, result);

        }
    }
}
