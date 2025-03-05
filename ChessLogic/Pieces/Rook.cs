using ChessLogic;

public class Rook : Piece
{
    public override PieceType Type => PieceType.Rook;
    public override Player Color { get; }

    private static readonly Direction[] dirs = new Direction[]
        {
            Direction.Up,
            Direction.Right,
            Direction.Down,
            Direction.Left, 
        };
    public Rook(Player color)
    {
        Color = color;
    }
    public override Piece Copy()
    {
        Rook copy = new Rook(Color);
        copy.HasMoved = HasMoved;
        return copy;
    }
    public override IEnumerable<Move> GetMoves(Board board, Position from)
    {
        return MovePositionsInDirs(board, from, dirs)
            .Select(to => new NormalMove(from, to));
    }
}
