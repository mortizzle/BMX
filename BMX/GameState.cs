using System.Dynamic;

namespace BMX
{
    internal record GameState
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GameState() => (X, Y) = (960, 540);
    }
}

