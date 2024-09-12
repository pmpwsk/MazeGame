using uwap.GameLibrary;

//Set width and height
int width = 15;
int height = 9;

//Create level object
Level l1 = new(width, height, new List<Thing>[width, height]);

//Create fields with background
for (int y = 0; y < l1.Height; y++)
    for (int x = 0; x < l1.Width; x++)
    {
        l1.Fields[x, y] = new List<Thing>();
        l1.Fields[x, y].Add(new Background());
    }

//Create and add player
Player p1 = new Player(l1, 0, 0);
l1.Fields[0, 0].Add(p1);

//Create and add target
l1.Fields[width-1, height-1].Add(new Target());


//Create and add walls
for (int y = 0; y < 8; y++)
    l1.Fields[1, y].Add(new Wall());
    
for (int y = 3; y < 9; y++)
    l1.Fields[3, y].Add(new Wall());
    
for (int y = 0; y < 4; y++)
    l1.Fields[10, y].Add(new Wall());
    
for (int y = 2; y < 5; y++)
    l1.Fields[5, y].Add(new Wall());
    
for (int y = 1; y < 9; y++)
    l1.Fields[13, y].Add(new Wall());

for (int x = 3; x < 9; x++)
    l1.Fields[x, 1].Add(new Wall());

for (int x = 7; x < 9; x++)
    l1.Fields[x, 3].Add(new Wall());

for (int x = 5; x < 13; x++)
    l1.Fields[x, 5].Add(new Wall());

for (int x = 5; x < 12; x++)
    l1.Fields[x, 7].Add(new Wall());

l1.Fields[6, 8].Add(new Wall());

l1.Fields[12, 3].Add(new Wall());

l1.Fields[11, 1].Add(new Wall());


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
    }

    return false;
}