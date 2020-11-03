using System.Numerics;

namespace BMX
{
    public class Bmx
    {
        public Vector2 Position { get; set; }
        public double FrameBearing { get; set; }
        public double HandleBarsAngle { get; set; } // 0 for straight
        public Vector2 TargetPoint { get; set; }
    }
}