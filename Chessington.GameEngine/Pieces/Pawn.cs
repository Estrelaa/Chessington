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

            if (this.HasMoved == false)
            {
                if (pawn.Player == Player.Black)
                {
                    availableSquares.Add(Square.At(currentSquare.Row + 2, currentSquare.Col));
                    availableSquares.Add(Square.At(currentSquare.Row + 1, currentSquare.Col));
                }
                else if (pawn.Player == Player.White)
                {
                    availableSquares.Add(Square.At(currentSquare.Row - 2, currentSquare.Col));
                    availableSquares.Add(Square.At(currentSquare.Row - 1, currentSquare.Col));
                }
                
            }
            else
            {
                if (pawn.Player == Player.Black)
                {
                    availableSquares.Add(Square.At(currentSquare.Row + 1, currentSquare.Col));
                }
                else if (pawn.Player == Player.White)
                {
                    availableSquares.Add(Square.At(currentSquare.Row - 1, currentSquare.Col));
                }
                
            }
            return availableSquares;
        }
    }
}