namespace BMX
{
    internal static class Math
    {
        public static double Sine(double degrees)
        {
            return System.Math.Sin(DegreesToRadians(degrees));
        }

        public static double Cosine(double degrees)
        {
            return System.Math.Cos(DegreesToRadians(degrees));
        }

        public static double DegreesToRadians(double degrees)
        {
            return System.Math.PI * degrees / 180;
        }

        public static double RadiansToDegrees(double radians)
        {
            return 180 * radians / System.Math.PI;
        }
    }
}
