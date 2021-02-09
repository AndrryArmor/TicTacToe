using Core.Abstraction;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Implementation
{
    public class GameEngine : IGameEngine
    {
        private readonly List<IMoveRule> _moveRules;
        private readonly List<IVictoryRule> _victoryRules;

        public GameEngine(List<IMoveRule> moveRules, List<IVictoryRule> victoryRules)
        {
            _moveRules = moveRules;
            _victoryRules = victoryRules;
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