using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player)
        {
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {

            var availableSquares = new List<Square>();
            var currentSquare = board.FindPiece(this);
            var pawn = new Pawn(Player);

            return AddMoves(availableSquares, currentSquare, pawn);
        }

        private List<Square> AddMoves(List<Square> availableSquares, Square currentSquare, Pawn pawn)
        {
            if (this.HasMoved == false)
            {
                switch (pawn.Player)
                {
                    case Player.Black:
                        availableSquares.Add(Square.At(currentSquare.Row + 2, currentSquare.Col));
                        availableSquares.Add(Square.At(currentSquare.Row + 1, currentSquare.Col));
                        break;
                    case Player.White:
                        availableSquares.Add(Square.At(currentSquare.Row - 2, currentSquare.Col));
                        availableSquares.Add(Square.At(currentSquare.Row - 1, currentSquare.Col));
                        break;
                    default:
                        throw new Exception("No player colours found");
                }
            }
            else
            {
                switch (pawn.Player)
                {
                    case Player.Black:
                        availableSquares.Add(Square.At(currentSquare.Row + 1, currentSquare.Col));
                        break;
                    case Player.White:
                        availableSquares.Add(Square.At(currentSquare.Row - 1, currentSquare.Col));
                        break;
                    default:
                        throw new Exception("No player colours found");
                }
            }

            return availableSquares;
        }
    }
}
