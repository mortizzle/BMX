using BMX.Engine.Interfaces;
using BMX.Models;
using System;

namespace BMX
{
    internal class GameEngine : IGameEngine
    {
        public GameState UpdateGameState(GameState gameState)
        {
            if (gameState.Paused) return gameState;

            gameState.GameTicks++;

            return gameState;
        }

        public int GetTickLength(GameState gameState)
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
