using uwap.GameLibrary;

//Set width and height
int width = 15;
int height = 9;

//Set player position
int playerX = 0;
int playerY = 0;

//Set target / player 2 position
int targetX = 14;
int targetY = 8;

//Create level object
Level l1 = new(width, height, width, height, new List<Thing>[width, height]);

//Create fields with background
for (int y = 0; y < l1.Height; y++)
    for (int x = 0; x < l1.Width; x++)
    {
        l1.Fields[x, y] = new List<Thing>();
        l1.Fields[x, y].Add(new Background());
    }

//Game mode settings, player and target creation
MovingThing p1, p2;
if (args.Length > 0 && args[0] == "coop")
{
    MultiPlayer mp1 = new(l1, playerX, playerY);
    mp1.SetContent(new(ConsoleColor.DarkBlue, "]["));
    p1 = mp1;
    l1.Fields[playerX, playerY].Add(p1);
    MultiPlayer mp2 = new(l1, targetX, targetY);
    mp2.SetContent(new(ConsoleColor.DarkYellow, "]["));
    p2 = mp2;
    l1.Fields[targetX, targetY].Add(p2);
}
else
{
    p1 = new Player(l1, playerX, playerY);
    l1.Fields[playerX, playerY].Add(p1);
    p2 = p1;
    l1.Fields[targetX, targetY].Add(new Target());
}

//Create and add walls
VerticalWall(1, new(0, 7));
VerticalWall(3, new(3, 8));
VerticalWall(10, new(0, 3));
VerticalWall(5, new(2, 4));
VerticalWall(13, new(1, 8));

HorizontalWall(new(3, 8), 1);
HorizontalWall(new(7, 8), 3);
HorizontalWall(new(5, 12), 5);
HorizontalWall(new(5, 11), 7);

SingleWall(6, 8);
SingleWall(12, 3);
SingleWall(11, 1);


//Set key function
l1.KeyFunction = KeyFunction;

//Start game
l1.Run();



//Define key function
bool KeyFunction(ConsoleKey key)
{
    switch (key)
    {
        case ConsoleKey.Escape:
            return true;
        case ConsoleKey.A:
            return p1.MoveBy(-1, 0);
        case ConsoleKey.D:
            return p1.MoveBy(1, 0);
        case ConsoleKey.W:
            return p1.MoveBy(0, -1);
        case ConsoleKey.S:
            return p1.MoveBy(0, 1);
        case ConsoleKey.LeftArrow:
            return p2.MoveBy(-1, 0);
        case ConsoleKey.RightArrow:
            return p2.MoveBy(1, 0);
        case ConsoleKey.UpArrow:
            return p2.MoveBy(0, -1);
        case ConsoleKey.DownArrow:
            return p2.MoveBy(0, 1);
    }

    return false;
}

void VerticalWall(int x, Tuple<int,int> yRange)
{
    for (int y = yRange.Item1; y <= yRange.Item2; y++)
        l1.Fields[x, y].Add(new Wall());
}

void HorizontalWall(Tuple<int,int> xRange, int y)
{
    for (int x = xRange.Item1; x <= xRange.Item2; x++)
        l1.Fields[x, y].Add(new Wall());
}

void SingleWall(int x, int y)
{
    l1.Fields[x, y].Add(new Wall());
}