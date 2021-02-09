using Core.Entities;

namespace Core.Abstraction
{
    public interface IGameEngine
    {
        bool IsMoveValid(Cell cell);
        bool IsVictory(Field field);
    }
}