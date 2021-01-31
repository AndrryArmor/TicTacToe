using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.MoveRules
{
    public class CanMoveOnEmptyCell : IMoveRule
    {
        public bool IsMoveValid(Cell cell)
        {
            return cell.State == CellState.Empty;
        }
    }
}
