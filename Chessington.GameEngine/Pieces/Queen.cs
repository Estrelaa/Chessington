using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableSquares = new List<Square>();
            var currentSquare = board.FindPiece(this);
            var BoardSize = GameSettings.BoardSize;

            Diagonally(availableSquares, currentSquare, BoardSize);

            availableSquares.RemoveAll(s => s.Row > 7 || s.Row < 0 || s.Col > 7 || s.Col < 0);

            Laterally(availableSquares, currentSquare, BoardSize);

            availableSquares.RemoveAll(s => s == Square.At(currentSquare.Row, currentSquare.Col));

            return availableSquares;
        }

        private static void Laterally(List<Square> availableSquares, Square currentSquare, int BoardSize)
        {
            LatRow(availableSquares, currentSquare, BoardSize);
            LatCol(availableSquares, currentSquare, BoardSize);
        }

        private static void Diagonally(List<Square> availableSquares, Square currentSquare, int BoardSize)
        {
            for (var i = 1; i <= BoardSize; i++)
            {
                availableSquares.Add(Square.At(currentSquare.Row + i, currentSquare.Col + i));
                availableSquares.Add(Square.At(currentSquare.Row + i, currentSquare.Col - i));
                availableSquares.Add(Square.At(currentSquare.Row - i, currentSquare.Col + i));
                availableSquares.Add(Square.At(currentSquare.Row - i, currentSquare.Col - i));
            }
        }

        private static void LatCol(List<Square> availableSquares, Square currentSquare, int BoardSize)
        {
            for (var i = 0; i < BoardSize; i++)
                availableSquares.Add(Square.At(currentSquare.Row, i));
        }

        private static void LatRow(List<Square> availableSquares, Square currentSquare, int BoardSize)
        {
            for (var i = 0; i < BoardSize; i++)
                availableSquares.Add(Square.At(i, currentSquare.Col));
        }
    }
}