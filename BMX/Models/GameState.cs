using System.Collections.Immutable;
using System.Numerics;

namespace BMX
{
    internal record GameState
    {
        public bool Paused { get; set; }
        public long GameTicks { get; set; }
        public GameSpeed GameSpeed { get; set; }

        public ImmutableList<TrackSegment> TrackSegments { get; set; }

        public ImmutableList<Bmx> Bmxes { get; set; }

        public GameState()
        {
            TrackSegments = ImmutableList.Create(new TrackSegment { Position = new Vector2(960,540), Type = TrackType.StartLine });
            Bmxes = ImmutableList.Create<Bmx>();
            Paused = false;
            GameSpeed = GameSpeed.Normal;
        }

        internal GameState WithAdditionalTrackSegment(TrackSegment trackSegment)
        {
            TrackSegments = TrackSegments.Add(trackSegment);
            return this;
        }

        internal GameState WithAdditionalBmxes(Bmx bmx)
        {
            Bmxes = Bmxes.Clear().Add(bmx);
            return this;
        }
    }
}

