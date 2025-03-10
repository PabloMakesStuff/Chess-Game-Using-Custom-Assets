﻿namespace ChessLogic
{
    public class Direction
    {
        public readonly static Direction Up = new Direction(1, 0);
        public readonly static Direction Down = new Direction(-1, 0);
        public readonly static Direction Left = new Direction(0, -1);
        public readonly static Direction Right = new Direction(0, 1);
        // Pokreti normalni
        public readonly static Direction UpLeft = Up + Left;
        public readonly static Direction UpRight = Up + Right;
        public readonly static Direction DownLeft = Down + Left;
        public readonly static Direction DownRight = Down + Right;
        // Pokreti po diagonali
        

        public int RowDelta { get; }
        public int ColumnDelta { get; }

        public Direction(int rowDelta, int columnDelta)
        {
            RowDelta = rowDelta;
            ColumnDelta = columnDelta;
        }

        public static Direction operator +(Direction dir1, Direction dir2)
        {
            return new Direction(dir1.RowDelta + dir2.RowDelta, dir1.ColumnDelta + dir2.ColumnDelta);
        }

        public static Direction operator *(int scalar, Direction dir)
        {
            return new Direction(dir.RowDelta * scalar, dir.ColumnDelta * scalar);
        }
    }
}
