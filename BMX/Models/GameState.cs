using System.Collections.Immutable;
using System.Numerics;

namespace BMX
{
    internal record GameState
    {
        public bool Paused { get; set; }
        public long GameTicks { get; set; }
        public GameSpeed GameSpeed { get; set; }

        public GameState()
        {
        }
    }
}

