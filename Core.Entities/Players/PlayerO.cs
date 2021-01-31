using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Players
{
    public class PlayerO : IPlayer
    {
        public void PutPiece(Cell cell)
        {
            cell.Piece = new Piece('O', this);
        }
    }
}
