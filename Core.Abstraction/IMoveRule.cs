using Core.Entities;

namespace Core.Abstraction
{
    public interface IMoveRule
    {
        bool IsMoveValid(Cell cell);
    }
}