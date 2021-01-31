using Core.Entities.Fields;
using System;

namespace Core.Entities
{
    public class Cell
    {
        private Piece piece = null;

        public Cell(Field field)
        {
            Field = field;
        }

        public virtual Piece Piece
        {
            get => piece;
            set
            {
                piece = value;

                State = (value != null)
                    ? CellState.Filled
                    : CellState.Empty;
            }
        }
        public CellState State { get; protected set; } = CellState.Empty;
        public Field Field { get; }
    }
}