using Core.Abstraction;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Implementation
{
    public class RealPlayer : IPlayer
    {
        private readonly PieceType _piece;

        public RealPlayer(PieceType piece)
        {
            _piece = piece;
        }

        public void PutPiece(Cell cell)
        {
            cell.Piece = _piece;
        }
    }
}
