using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessLogic;

namespace ChessLogic
{
    public class King : Piece
    {
        public override PieceType Type => PieceType.King;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]
        {
        Direction.Up,
        Direction.Down,
        Direction.Left,
        Direction.Right,
        Direction.UpLeft,
        Direction.UpRight,
        Direction.DownLeft,
        Direction.DownRight
        };
        public King(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            King copy = new King(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private IEnumerable<Position> MovePositions(Board board, Position from)
        {
            foreach (Direction dir in dirs)
            {
                Position to = from + dir;
                if (!Board.IsInside(to))
                {
                    continue;
                }

                if (board.IsEmpty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Board board, Position from)
        {
            foreach (Position to in MovePositions(board, from))
            {
                yield return new NormalMove(from, to);
            }
        }   
    }
}