using BMX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMX.Engine.Interfaces
{
    public interface IGameEngine
    {
        GameState UpdateGameState(GameState gameState);
        int GetTickLength(GameState gameState);
    }
}
