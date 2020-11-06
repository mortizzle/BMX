using System.DirectoryServices;
using System.Drawing;
using System.Drawing.Drawing2D;
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
    }
}
