using uwap.GameLibrary;

public class Wall : SolidThing
{
    public override ConsoleColor? BackgroundColor => ConsoleColor.Red;

    public override Content? Content => null;
}