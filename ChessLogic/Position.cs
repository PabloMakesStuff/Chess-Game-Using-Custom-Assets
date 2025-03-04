namespace ChessLogic
{
    internal class Position
    {
        public int Row {  get; } // y osa
        public int Column { get; } // x osa

        /* U tutorialu koji ja gledam on predpostavlja da (0,0) krece od gornje leve kocke
        ali ja cu da predpostavim da (0,0) krece od donje leve kocke i da ne krece od (0,0)
        nego od (1,1) dodacu +1 na sve kordinate */

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Player SquareColor()
        {
            if((Row + Column) % 2 == 0)
                return Player.White;
            
            return Player.Black;
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   Row == position.Row &&
                   Column == position.Column;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);
        }

        public static bool operator ==(Position left, Position right)
        {
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }

        public static Position operator +(Position pos, Direction dir)
        {
            return new Position(pos.Row + dir.RowDelta, pos.Column + dir.ColumnDelta);
        }
    }
}
