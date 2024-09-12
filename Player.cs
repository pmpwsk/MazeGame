using uwap.GameLibrary;

public class Player : Thing
{
    public override ConsoleColor Color => ConsoleColor.Yellow;

    private Level Level;

    private int X;
    
    private int Y;

    public Player(Level level, int x, int y)
    {
        Level = level;
        X = x;
        Y = y;
    }

    public bool MoveTo(int x, int y)
    {
        if (x >= 0 && x < Level.Width && y >= 0 && y < Level.Height)
        {
            if (Level.Fields[x, y].Any(obj => obj is Wall))
                return false;

            Level.Fields[X, Y].Remove(this);
            Level.Fields[x, y].Add(this);
            X = x;
            Y = y;
            if (Level.Fields[X, Y].Any(obj => obj is Target))
            {
                Console.CursorTop -= Level.Height;
                Level.PrintToConsole();
                Console.WriteLine("Geschafft!");
                return true;
            }
        }
        
        return false;
    }

    public bool MoveBy(int xOffset, int yOffset)
    {
        return MoveTo(X + xOffset, Y + yOffset);
    }
}