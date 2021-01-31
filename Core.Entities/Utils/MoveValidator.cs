using Core.Entities.MoveRules;
using System.Collections.Generic;

namespace Core.Entities.Utils
{
    public sealed class MoveValidator
    {
        private readonly List<IMoveRule> _moveRules;

        public MoveValidator(List<IMoveRule> moveRules)
        {
            _moveRules = moveRules;
        }

        public bool IsMoveValid(Cell cell)
        {
            foreach (var moveRule in _moveRules)
            {
                if (!moveRule.IsMoveValid(cell))
                    return false;
            }
            return true;
        }
    }
}