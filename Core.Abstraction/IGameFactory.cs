using Core.Entities;

namespace Core.Abstraction
{
    public interface IGameFactory
    {
        Field CreateField();
        IPlayer CreateFirstPlayer();
        IPlayer CreateSecondPlayer();
        IGameEngine GetGameEngine();
    }
}