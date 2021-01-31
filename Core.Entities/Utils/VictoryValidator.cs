using Core.Entities.Fields;
using Core.Entities.VictoryRules;
using System.Collections.Generic;

namespace Core.Entities.Utils
{
    public sealed class VictoryValidator
    {
        private readonly List<IVictoryRule> _victoryRules;

        public VictoryValidator(List<IVictoryRule> victoryRules)
        {
            _victoryRules = victoryRules;
        }

        public bool IsVictory(Field field)
        {
            foreach (var victoryRule in _victoryRules)
            {
                if (!victoryRule.IsVictory(field))
                    return false;
            }
            return true;
        }
    }
}