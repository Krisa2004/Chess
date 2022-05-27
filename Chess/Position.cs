namespace Chess;

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public int Row => Y;
    public int Column => X;

    public Position(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public int ToPixelX(int baseX)
    {
        return baseX + (X - 1) * 60;
    }

    public int toPixelY(int baseY)
    {
        return baseY - (Y - 1) * 60;
    }

    public Position Clone()
    {
        return new Position(X, Y);
    }

    public override string ToString()
    {
        return "" + (char)('A' + (Column - 1)) + Row;
    }
}