using Core.Abstraction;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Implementation
{
    public class ThreeHorizontalPiecesVictory : IVictoryRule
    {
        public bool IsVictory(Field field)
        {
            for (int i = 0; i < field.Width; i++)
            {
                for (int j = 0; j < field.Height - 2; j++)
                {
                    if (field[i, j].Piece == field[i, j + 1].Piece
                        && field[i, j + 1].Piece == field[i, j + 2].Piece)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
