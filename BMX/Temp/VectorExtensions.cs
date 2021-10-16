using System.Numerics;

namespace BMX
{
    internal static class VectorExtensions
    {
        public static Vector2 RotateAbout(this Vector2 point, Vector2 rotationPoint, double rotationAngle)
        {
            double cosTheta = Math.Cosine(rotationAngle);
            double sinTheta = Math.Sine(rotationAngle);

            var newX =
                    (int)
                    (cosTheta * (point.X - rotationPoint.X) -
                    sinTheta * (point.Y - rotationPoint.Y) + rotationPoint.X);

            var newY = (int)
                    (sinTheta * (point.X - rotationPoint.X) +
                    cosTheta * (point.Y - rotationPoint.Y) + rotationPoint.Y);

            return new Vector2(newX, newY);
        }

        public static float BearingTo(this Vector2 point, Vector2 targetPoint)
        {
            var xDiff = point.X - targetPoint.X;
            var yDiff = point.Y - targetPoint.Y;
            var radians = System.Math.Atan2(yDiff, xDiff);
            var bearing  = (float) Math.RadiansToDegrees(radians);
            if (bearing < 0) bearing += 360;

            return bearing;
        }
    }
}
