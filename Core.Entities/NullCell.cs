using Core.Entities.Fields;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class NullCell : Cell
    {
        public NullCell(Field field) : base(field)
        {
            State = CellState.Null;
        }

        public override Piece Piece 
        { 
            get => base.Piece;
            set { }
        }
    }
}
