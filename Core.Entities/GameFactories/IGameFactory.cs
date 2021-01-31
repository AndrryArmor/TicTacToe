using Core.Entities.Fields;
using Core.Entities.Players;
using Core.Entities.Utils;

namespace Core.Entities.GameFactories
{
    public interface IGameFactory
    {
        Field CreateField(FieldParameters fieldParameters);
        IPlayer CreateFirstPlayer();
        IPlayer CreateSecondPlayer();
        MoveValidator GetMoveValidator();
        VictoryValidator GetVictoryValidator();
    }
}