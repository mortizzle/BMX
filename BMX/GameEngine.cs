using System;

namespace BMX
{
    internal static class GameEngine
    {
        public static GameState UpdateGameState(GameState gameState)
        {
            return gameState with { X = gameState.X + new Random().Next(20) - 10, Y = gameState.Y + new Random().Next(20) - 10 };
        }

    }
}
