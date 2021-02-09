using Core.Abstraction;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Implementation
{
    public class CanMoveOnEmptyCell : IMoveRule
    {
        public bool IsMoveValid(Cell cell)
        {
            return cell.Piece == null;
        }
    }
}
