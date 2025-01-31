public class GameField
{
    private readonly string _layout = @"
        ----------------------------------------
        |                                      |
        |                                      |
        |                                      |
        ----------------------------------------
        |                                      |
        |                                      |
        |                                      |
        ----------------------------------------  0
        |                                      |
        |                                      |
        |                                      |
        ----------------------------------------
        |                                      |
        |                                      |
        |                                      |
        ----------------------------------------
        ";

    public string GetLayout()
    {
        return _layout;
    }
    public void RoundCount()
    {
        round++;
    }

    public int RoundReturn()
    {
        return round;
    }
}
