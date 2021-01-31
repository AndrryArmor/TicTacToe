using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Fields
{
    public class RectangularField : Field
    {
        public RectangularField(int width, int height) : base(width, height)
        {            
        }

        protected override Cell[,] CreateFieldCells(int width, int height)
        {
            var cells = new Cell[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    cells[i, j] = new Cell(this);
                }
            }

            return cells;
        }
    }
}
