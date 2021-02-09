using System;

namespace Core.Entities
{
    public class Cell
    {
        public Cell(int row, int column, Field field)
        {
            Row = row;
            Column = column;
            Field = field;
        }

        public int Row { get; }
        public int Column { get; }

        public PieceType? Piece { get; set; } = null;
        public Field Field { get; }
    }
}