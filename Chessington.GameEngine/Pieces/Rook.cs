using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableSquares = new List<Square>();
            var currentSquare = board.FindPiece(this);
            var BoardSize = GameSettings.BoardSize;

            for (var i = 0; i < BoardSize; i++)
                availableSquares.Add(Square.At(i, currentSquare.Col));

            for (var i = 0; i < BoardSize; i++)
                availableSquares.Add(Square.At(currentSquare.Row, i));

            return availableSquares;
        }
    }
}