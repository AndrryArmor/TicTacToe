using Core.Entities;
using Core.Entities.Fields;
using Core.Entities.GameFactories;
using Core.Entities.Players;
using Core.Entities.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class GameController
    {
        private readonly IPlayer _firstPlayer;
        private readonly IPlayer _secondPlayer;
        private readonly MoveValidator _moveValidator;
        private readonly VictoryValidator _victoryValidator;

        public GameController(IGameFactory gameFactory, FieldParameters fieldParameters)
        {
            Field = gameFactory.CreateField(fieldParameters);
            _firstPlayer = gameFactory.CreateFirstPlayer();
            _secondPlayer = gameFactory.CreateSecondPlayer();
            _moveValidator = gameFactory.GetMoveValidator();
            _victoryValidator = gameFactory.GetVictoryValidator();
        }

        public event EventHandler<VictoryEventArgs> OnVictory;
        public event EventHandler OnQuitGame;

        public GameState State { get; private set; } = GameState.Stopped;
        public Field Field { get; }
        public Player CurrentPlayer { get; private set; }

        public void NewGame()
        {
            CurrentPlayer = Player.First;
            State = GameState.Running;
        }

        public void QuitGame()
        {
            OnQuitGame?.Invoke(this, EventArgs.Empty);
        }

        public void MakeMove(Cell cell)
        {
            if (State == GameState.Stopped || !_moveValidator.IsMoveValid(cell))
                return;
            
            PutPiece(cell);
            if (_victoryValidator.IsVictory(Field))
            {
                State = GameState.Stopped;
                OnVictory?.Invoke(this, new VictoryEventArgs(CurrentPlayer));
            }
            else
            {
                NextPlayer();
            }
        }

        private void PutPiece(Cell cell)
        {
            switch (CurrentPlayer)
            {
                case Player.First:
                    _firstPlayer.PutPiece(cell);
                    break;
                case Player.Second:
                    _secondPlayer.PutPiece(cell);
                    break;
            }
        }

        private void NextPlayer()
        {
            switch (CurrentPlayer)
            {
                case Player.First:
                    CurrentPlayer = Player.Second;
                    break;
                case Player.Second:
                    CurrentPlayer = Player.First;
                    break;
            }
        }

    }
}