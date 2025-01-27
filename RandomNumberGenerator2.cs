namespace Pencil_Tennis.P2;

public class RandomNumberGenerator2
{
    private static readonly Random _random = new();
    public int Max2;
    public int Min2 = 0;
    public int Number2;

    public void Generate(int Min2, int Max2)
    {
        var points = new Player2();
        Max2 = points.P2Points;

        if (Max2 < Min2)
        {
            Max2 = Min2;
        }

        Number2 = _random.Next(Min2, Max2 + 1);
    }
}
