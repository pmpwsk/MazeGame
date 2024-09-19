using uwap.GameLibrary;

public class Target : EnterEventThing
{
    public override ConsoleColor? BackgroundColor => ConsoleColor.Green;

    public override Content? Content => null;

    public override bool OnEnter(Thing sender)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Done!");
        Console.ResetColor();
        return true;
    }
}