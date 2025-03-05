using ChessLogic;

public class Queen : Piece
{
    public override PieceType Type => PieceType.Queen;
    public override Player Color { get; }

    private static readonly Direction[] dirs = new Direction[]
        {
            Direction.Up,
            Direction.Right,
            Direction.Down,
            Direction.Left,
            Direction.UpLeft,
            Direction.UpRight,
            Direction.DownLeft,
            Direction.DownRight,
        };
    public Queen(Player color)
    {
        Color = color;
    }
    public override Piece Copy()
    {
        Queen copy = new Queen(Color);
        copy.HasMoved = HasMoved;
        return copy;
    }
    public override IEnumerable<Move> GetMoves(Board board, Position from)
    {
        return MovePositionsInDirs(board, from, dirs)
            .Select(to => new NormalMove(from, to));
    }
}
