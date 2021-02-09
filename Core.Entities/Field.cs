using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.Entities
{
    public class Field
    {
        private readonly Cell[,] _cells;

        public Field(int width, int height)
        {
            Width = width;
            Height = height;
            InitialiseCells(_cells);
        }

        public int Width { get; }
        public int Height { get; }

        public Cell this[int row, int column]
        {
            get
            {
                try
                {
                    return _cells[row, column];
                }
                catch (IndexOutOfRangeException ex)
                {
                    throw new ArgumentException("Row and/or column indexes are out of range", ex);
                }
            }
            set
            {
                try
                {
                    _cells[row, column] = value;
                }
                catch (IndexOutOfRangeException ex)
                {
                    throw new ArgumentException("Row and/or column indexes are out of range", ex);
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
                cell.Piece = null;
            }
        }

        private void InitialiseCells(Cell[,] cells)
        {
            cells = new Cell[Width, Height];

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    cells[i, j] = new Cell(i, j, this);
                }
            }
        }
    }
}
