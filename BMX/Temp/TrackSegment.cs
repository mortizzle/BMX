using System.Numerics;

namespace BMX
{
    public record TrackSegment
    {
        public Vector2 Position { get; set; }
        public TrackType Type { get; set; }
    }
}