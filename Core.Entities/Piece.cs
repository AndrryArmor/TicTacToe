using Core.Entities.Players;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Piece
    {
        public Piece(char symbol, IPlayer player)
        {
            Symbol = symbol;
            Player = player;
        }

        public char Symbol { get; }
        public IPlayer Player { get; }

        public override bool Equals(object obj)
        {
            return obj is Piece piece &&
                   Symbol == piece.Symbol;
        }

        public override int GetHashCode()
        {
            return -1758840423 + Symbol.GetHashCode();
        }

        public static bool operator ==(Piece left, Piece right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Piece left, Piece right)
        {
            return !(left == right);
        }
    }
}