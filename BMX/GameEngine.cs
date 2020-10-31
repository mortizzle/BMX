using System;

namespace BMX
{
    internal static class GameEngine
    {
        public static GameState UpdateGameState(GameState gameState)
        {
            gameState.X += new Random().Next(20) - 10;
            gameState.Y += new Random().Next(20) - 10;

            return gameState;
        }

    }
}
