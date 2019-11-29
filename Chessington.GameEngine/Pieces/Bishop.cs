using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableSquares = new List<Square>();
            var currentSquare = board.FindPiece(this);
            var BoardSize = GameSettings.BoardSize;

            Diagonally(availableSquares, currentSquare, BoardSize);

            availableSquares.RemoveAll(s => s.Row > 7 || s.Row < 0 || s.Col > 7 || s.Col < 0);

            return availableSquares;
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
    }
}