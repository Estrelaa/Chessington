using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> AvailableSquares = new List<Square>();
            AvailableSquares.Add(Square.At(6, 0));
            AvailableSquares.Add(Square.At(2, 0));
            return AvailableSquares;
        }

    }
}