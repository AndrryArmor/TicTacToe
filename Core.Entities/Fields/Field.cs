using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Fields
{
    public abstract class Field
    {
        private readonly Cell[,] _cells;

        protected Field(int width, int height)
        {
            Width = width;
            Height = height;
            _cells = CreateFieldCells(Width, Height);
        }

        public int Width { get; }
        public int Height { get; }

        public Cell this[int row, int column]
        {
            get
            {
                if (0 <= row && row < _cells.GetLength(0) &&
                    0 <= column && column < _cells.GetLength(1))
                {
                    return _cells[row, column];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (0 <= row && row < _cells.GetLength(0) &&
                    0 <= column && column < _cells.GetLength(1))
                {
                    _cells[row, column] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public Cell[,] GetCells()
        {
            return _cells;
        }

        public void Clear()
        {
            foreach (var cell in _cells)
            {
                if (cell.State != CellState.Null)
                    cell.Piece = null;
            }
        }

        protected abstract Cell[,] CreateFieldCells(int width, int height);
    }
}
