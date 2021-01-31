using Core.Entities.Fields;
using Core.Entities.MoveRules;
using Core.Entities.Players;
using Core.Entities.Utils;
using Core.Entities.VictoryRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.GameFactories
{
    public class ClassicTicTacToeGameFactory : IGameFactory
    {
        public Field CreateField(FieldParameters fieldParameters)
        {
            if (fieldParameters != null)
                throw new ArgumentException("Field parameters must be null for classic tic tac toe");

            return new RectangularField(3, 3);
        }

        public IPlayer CreateFirstPlayer()
        {
            return new PlayerX();
        }

        public IPlayer CreateSecondPlayer()
        {
            return new PlayerO();
        }

        public MoveValidator GetMoveValidator()
        {
            List<IMoveRule> moveRules = new List<IMoveRule>();
            moveRules.Add(new CanMoveOnEmptyCell());

            return new MoveValidator(moveRules);
        }

        public VictoryValidator GetVictoryValidator()
        {
            List<IVictoryRule> victoryRules = new List<IVictoryRule>();
            victoryRules.Add(new ThreeHorizontalPiecesVictory());
            victoryRules.Add(new ThreeVerticalPiecesVictory());
            victoryRules.Add(new ThreeDiagonalPiecesVictory());

            return new VictoryValidator(victoryRules);
        }
    }
}
