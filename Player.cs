using uwap.GameLibrary;

public class Player(Level level, int x, int y) : MovingThing(level, x, y)
{
    public override ConsoleColor? BackgroundColor => null;

    public override Content? Content => new(ConsoleColor.DarkBlue, "][");
}