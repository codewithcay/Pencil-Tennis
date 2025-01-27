namespace Pencil_Tennis.P1;

public class Player1
{
    public int P1NextChoice;
    public int P1Points = 50;
    public int P1Score;
    public int Bet { get; set; }

    public void GetNextChoice()
    {
        var numberGenerator = new RandomNumberGenerator1();
        numberGenerator.Generate(0, P1Points);
        P1NextChoice = numberGenerator.Number;
    }

    public void LowerScore(int points)
    {
        P1Score -= points;
    }

    public void IncreaseScore(int points)
    {
        P1Score += points;
    }

    public int GetScore()
    {
        return P1Score;
    }

    public void UpdatePoints(int bet1)
    {
        P1Points -= bet1;
    }

    public void ResetPoints()
    {
        P1Points = 50;
    }
}
