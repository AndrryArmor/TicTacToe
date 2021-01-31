using Core.Entities;

namespace Core.Entities.MoveRules
{
    public interface IMoveRule
    {
        bool IsMoveValid(Cell cell);
    }
}