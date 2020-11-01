using System;
using System.Collections.Immutable;
using System.Numerics;

namespace BMX
{
    internal record GameState
    {
        public ImmutableList<TrackSegment> TrackSegments { get; set; }

        public ImmutableList<Bmx> Bmxes { get; set; }

        public GameState()
        {
            TrackSegments = ImmutableList.Create(new TrackSegment { Position = new Vector2(960,540), Type = TrackType.StartLine });
            Bmxes = ImmutableList.Create<Bmx>();
        }

        internal GameState WithAdditionalTrackSegment(TrackSegment trackSegment)
        {
            TrackSegments = TrackSegments.Add(trackSegment);
            return this;
        }

        internal GameState WithAdditionalBmxes(Bmx bmx)
        {
            Bmxes = Bmxes.Add(bmx);
            return this;
        }
    }
}

