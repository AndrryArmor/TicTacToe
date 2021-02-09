using Core.Abstraction;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Implementation
{
    public class ClassicTicTacToeGameFactory : IGameFactory
    {
        public Field CreateField()
        {
            return new Field(3, 3);
        }

        public IPlayer CreateFirstPlayer()
        {
            return new RealPlayer(PieceType.X);
        }

        public IPlayer CreateSecondPlayer()
        {
            return new RealPlayer(PieceType.O);
        }

        public IGameEngine GetGameEngine()
        {
            List<IMoveRule> moveRules = new List<IMoveRule>
            {
                new CanMoveOnEmptyCell()
            };

            List<IVictoryRule> victoryRules = new List<IVictoryRule>
            {
                new ThreeHorizontalPiecesVictory(),
                new ThreeVerticalPiecesVictory(),
                new ThreeDiagonalPiecesVictory()
            };

            return new GameEngine(moveRules, victoryRules);
        }
    }
}
