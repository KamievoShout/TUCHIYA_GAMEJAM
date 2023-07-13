public enum Direction
{
    Top,
    Left,
    Bottom,
    Right
}

public static class DirectionExtension
{
    public static Direction Invert(this Direction dir)
    {
        switch (dir)
        {
            case Direction.Top:
                return Direction.Bottom;
            case Direction.Left:
                return Direction.Right;
            case Direction.Bottom:
                return Direction.Top;
            case Direction.Right:
                return Direction.Left;
        }
        return Direction.Left;
    }
}
