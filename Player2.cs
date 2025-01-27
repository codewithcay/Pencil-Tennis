namespace Pencil_Tennis.P2;

public class Player2
{
    public int P2NextChoice;
    public int P2Points = 50;
    public int P2Score;
    public int Bet2 { get; set; }

    public void GetNextChoice()
    {
        var numberGenerator = new RandomNumberGenerator2();
        numberGenerator.Generate(0, P2Points);
        P2NextChoice = numberGenerator.Number2;
    }

    public void LowerScore(int points)
    {
        P2Score -= points;
    }

    public void IncreaseScore(int points)
    {
        P2Score += points;
    }

    public int GetScore()
    {
        return P2Score;
    }

    public void UpdatePoints(int bet2)
    {
        P2Points -= bet2;
    }

    public void ResetPoints()
    {
        P2Points = 50;
    }
}
