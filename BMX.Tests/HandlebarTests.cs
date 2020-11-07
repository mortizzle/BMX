using Xunit;

namespace BMX.Tests
{
    public class HandlebarTests
    {
        [Theory]
        // Basic big andles
        [InlineData(0,0,0)]
        [InlineData(0, 90, 37)]
        [InlineData(0, 180, 37)]
        [InlineData(0, 270, -37)]
        // small angle that bisects 0 plane
        [InlineData(10, 350, -20)]
        // Larger angle started with offset
        [InlineData(50, 190, 37)]
        [InlineData(320, 40, 37)]
        public void TurnsTowardTargetBearingCorrectly(double frameBearing, double targetBearing, double expectedHandlebarAngle)
        {
            // Arrange
            var bmx = new Bmx() { FrameBearing = frameBearing };

            // Act
            var result = GameEngine.TurnHandleBarsTowardsBearing(bmx, targetBearing);

            // Assert
            Assert.Equal(expectedHandlebarAngle, result);
        }
    }
}
