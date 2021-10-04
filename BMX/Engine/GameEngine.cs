using System;

namespace BMX
{
    internal static class GameEngine
    {
        public static GameState UpdateGameState(GameState gameState)
        {
            if (gameState.Paused) return gameState;

            gameState.GameTicks++;

            return gameState;
        }

        internal static int GetTickLength(GameState gameState)
        {
            return gameState.GameSpeed switch
            {
                GameSpeed.Snail => 500,
                GameSpeed.Slow => 150,
                GameSpeed.Normal => 16,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
