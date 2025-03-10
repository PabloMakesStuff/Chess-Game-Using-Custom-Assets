﻿using System.Runtime.CompilerServices;

namespace ChessLogic
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }
        private readonly Direction forward;
        public Pawn(Player color)
        {
            Color = color;

            if (color == Player.White)
            {
                forward = Direction.Up;
            }
            else
            {
                forward = Direction.Down;
            }
        }

        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static bool CanMoveTo(Position pos, Board board)
        {
            return Board.IsInside(pos) && board.IsEmpty(pos);
        }

        private bool CanCaptureAt(Position pos, Board board)
        {
            if (!Board.IsInside(pos) || board.IsEmpty(pos))
            {
                return false;
            }

            return board[pos].Color != Color;
        }

        private IEnumerable<Move> ForwardMoves(Position from, Board board)
        {
            Position oneMovePos = from + forward;

            if (CanMoveTo(oneMovePos, board))
            {
                yield return new NormalMove(from, oneMovePos);

                Position twoMovePos = oneMovePos + forward;

                if (!HasMoved && CanMoveTo(twoMovePos, board))
                {
                    yield return new NormalMove(from, twoMovePos);
                }
            }
        }

        private IEnumerable<Move> DiagonalMoves(Position from, Board board)
        {
            foreach (Direction dir in new Direction[] { Direction.Left, Direction.Right })
            {
                Position to = from + forward + dir;

                if (CanCaptureAt(to, board))
                {
                    yield return new NormalMove(from, to);
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Board board, Position from)
        {
            return ForwardMoves(from, board).Concat(DiagonalMoves(from, board));
        }
    }
}
