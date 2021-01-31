using Core.Entities;
using Core.Entities.Fields;

namespace Core.Entities.VictoryRules
{
    public interface IVictoryRule
    {
        bool IsVictory(Field field);
    }
}