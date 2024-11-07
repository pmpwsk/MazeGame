using uwap.GameLibrary;

public class Target : EnterEventThing
{
    public ConsoleColor? BackgroundColor => ConsoleColor.Green;

    public Content? Content => null;

    public bool OnEnter(Thing sender)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Done!");
        Console.ResetColor();
        return true;
    }
}