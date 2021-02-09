using Core.Abstraction;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Implementation
{
    public class GameController
    {
        private readonly IPlayer _firstPlayer;
        private readonly IPlayer _secondPlayer;
        private readonly IGameEngine _gameEngine;

        public GameController(IGameFactory gameFactory)
        {
            Field = gameFactory.CreateField();
            _firstPlayer = gameFactory.CreateFirstPlayer();
            _secondPlayer = gameFactory.CreateSecondPlayer();
            _gameEngine = gameFactory.GetGameEngine();
        }

        public event EventHandler OnVictory;
        public event EventHandler OnQuitGame;

        public GameState State { get; private set; } = GameState.Stopped;
        public Field Field { get; }
        public PlayerNumber CurrentPlayer { get; private set; }

        public void NewGame()
        {
            CurrentPlayer = PlayerNumber.First;
            State = GameState.Running;
        }

        public void QuitGame()
        {
            OnQuitGame?.Invoke(this, EventArgs.Empty);
        }

        public void MakeMove(Cell cell)
        {
            if (State == GameState.Stopped || !_gameEngine.IsMoveValid(cell))
                return;
            
            CurrentPlayerPutPiece(cell);

            if (_gameEngine.IsVictory(Field))
            {
                State = GameState.Stopped;
                OnVictory?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                NextPlayer();
            }
        }

        private void CurrentPlayerPutPiece(Cell cell)
        {
            switch (CurrentPlayer)
            {
                case PlayerNumber.First:
                    _firstPlayer.PutPiece(cell);
                    break;
                case PlayerNumber.Second:
                    _secondPlayer.PutPiece(cell);
                    break;
            }
        }

        private void NextPlayer()
        {
            switch (CurrentPlayer)
            {
                case PlayerNumber.First:
                    CurrentPlayer = PlayerNumber.Second;
                    break;
                case PlayerNumber.Second:
                    CurrentPlayer = PlayerNumber.First;
                    break;
            }
        }

    }
}