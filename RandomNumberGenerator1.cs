namespace Pencil_Tennis.P1;

public class RandomNumberGenerator1
{
    private static readonly Random _random = new();
    public int Max;
    public int Min = 0;
    public int Number;

    public void Generate(int Min, int Max)
    {
        var points = new Player1();
        Max = points.P1Points;

        if (Max < Min)
        {
            Max = Min;
        }

        Number = _random.Next(Min, Max +1);
    }
}
