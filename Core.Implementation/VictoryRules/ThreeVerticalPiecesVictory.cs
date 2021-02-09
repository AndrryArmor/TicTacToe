using Core.Abstraction;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Implementation
{
    public class ThreeVerticalPiecesVictory : IVictoryRule
    {
        public bool IsVictory(Field field)
        {
            for (int i = 0; i < field.Width; i++)
            {
                for (int j = 0; j < field.Height - 2; j++)
                {
                    if (field[i, j].Piece == field[i + 1, j].Piece
                        && field[i + 1, j].Piece == field[i + 2, j].Piece)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
