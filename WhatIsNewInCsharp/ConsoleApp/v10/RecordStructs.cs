namespace ConsoleApp.v10;

public record struct Point<T>(T X, T Y);

public struct Coords
{
    public int X { get; }
    public int Y { get; }

    public Coords(int x, int y)
    {
        X = x;
        Y = y;  
    }
}

