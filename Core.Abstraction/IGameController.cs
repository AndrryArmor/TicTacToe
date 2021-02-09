using Core.Entities;
using System;

namespace Core.Abstraction
{
    public interface IGameController
    {
        event EventHandler OnVictory;
        event EventHandler OnQuitGame;

        Field Field { get; }
        GameState State { get; }
        PlayerNumber CurrentPlayer { get; }

        void NewGame();
        void QuitGame();
        void MakeMove(Cell cell);
    }
}