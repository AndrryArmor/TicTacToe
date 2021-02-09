using Core.Entities;

namespace Core.Abstraction
{
    public interface IVictoryRule
    {
        bool IsVictory(Field field);
    }
}