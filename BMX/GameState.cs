using System.Dynamic;

namespace BMX
{
    internal class GameState
    {
        public int X { get; set; }
        public int Y { get; set; }
        public GameState()
        {
            Reset();
        }

        public void Reset()
        {
            X = 960;
            Y = 540;
        }
    }
}

