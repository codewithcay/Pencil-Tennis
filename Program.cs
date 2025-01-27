using Pencil_Tennis;
using Pencil_Tennis.P1;
using Pencil_Tennis.P2;

var welcome = @"Welcome to Pencil Tennis!
The Rules:
1.Player1 and Player 2 will have 50 Points in the beginning
2.You will 'bet' these points, whoever bet more will get the 'hit'
    f.Ex. Player 1 bet 2p and Player2 bet 5p, then the ball will go in Player1's field
3. The Game is done when your the Ball goes OUT";
Console.WriteLine(welcome);
var gameField = new GameField();
Console.WriteLine(gameField.GetLayout());
Console.WriteLine("Press any key to continue...");
Console.ReadKey();
var player1 = new Player1();
var player2 = new Player2();
var p1F1 = false;
var p1F2 = false;
var p2F1 = false;
var p2F2 = false;
var gamefield = true;
player1.ResetPoints();

while (true)
{
    var nextGenerator1 = new RandomNumberGenerator1();
    var nextGenerator2 = new RandomNumberGenerator2();
    var bet1 = 0;
    var bet2 = 0;
    
    Console.WriteLine(@"Player1 set your bet.
    ATTENTION: Player2 is not allow to see the bet!!!");
    
    while (true)
    {
        nextGenerator1.Generate(1, player1.P1Points);
        bet1 = nextGenerator1.Number;

        if (bet1 >= 1 && bet1 <= player1.P1Points)
        {
            player1.Bet = bet1;
            break;
        }

        if (bet1 >= 1 && bet1 <= player1.P1Points)
            break;
    }


    Console.WriteLine("Bet is set!");
    Console.WriteLine(bet1);

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.WriteLine(@" Player2 set your bet. 
    ATTENTION: Player1 is not allow to see the bet!!!");

    while (true)
    {
        nextGenerator2.Generate(1, player2.P2Points);
        bet2 = nextGenerator2.Number2;

        if (bet2 >= 1 && bet2 <= player2.P2Points)
        {
            player2.Bet2 = bet2;
            break;
        }

        if (int.TryParse(nextGenerator2.Number2.ToString(), out bet2) && bet2 >= 0 && bet2 <= player2.P2Points)
            break;
    }
    
    Console.WriteLine("Bet is set!");
    Console.WriteLine(bet2);
    player1.UpdatePoints(bet1);
    player2.UpdatePoints(bet2);

    if (bet1 == bet2)
    {
        Console.WriteLine("Tie! The ball stays in current Field.");
        
        if (player1.P1Points <= 0)
        {
            Console.WriteLine("Player1 has no Points to bet. Player2 WINS!");
            break;
        }
                                                                   
        if (player2.P2Points <= 0)
        {
            Console.WriteLine("Player2 has no Points to bet. Player1 WINS!");
            break;
        }
    }
    else if (bet1 > bet2)
    {
        player2.LowerScore(1);
        player1.IncreaseScore(1);

        if (gamefield || p1F1 || p1F2)
        {
            Console.WriteLine("The Ball goes in Player2's first field");
            var ball = new BallP2F1();
            Console.WriteLine(ball.GetLayout());
            p2F1 = true;
            gamefield = false;
            p1F1 = false;
            p1F2 = false;
        }

        else if (p2F1)
        {
            Console.WriteLine("The Ball goes in Player2's second field");
            var ball = new BallP2F2();
            Console.WriteLine(ball.GetLayout());
            p2F2 = true;
            p2F1 = false;
            p1F2 = false;
            p1F1 = false;
        }

        else if (p2F2)
        {
            Console.WriteLine("OUT! PLAYER 1 WINS!");
            var gameField2 = new GameField();
            Console.WriteLine(gameField2.GetLayout());
            p2F2 = false;
            break;
        }
        if (player1.P1Points <= 0)
        {
            Console.WriteLine("Player1 has no Points to bet. Player2 WINS!");
            break;
        }

        else if (player2.P2Points <= 0)
        {
            Console.WriteLine("Player2 has no Points to bet. Player1 WINS!");
            break;
        }
    }
    else if (bet1 < bet2)
    {
        player2.IncreaseScore(1);
        player1.LowerScore(1);

        if (gamefield || p2F1 || p2F2)
        {
            Console.WriteLine("The Ball goes in Player1's first field");
            var ball = new BallP1F1();
            Console.WriteLine(ball.GetLayout());
            p1F1 = true;
            gamefield = false;
            p2F1 = false;
            p2F2 = false;
        }
        else if (p1F1)
        {
            Console.WriteLine("The Ball goes in Player2's second field");
            var ball = new BallP1F2();
            Console.WriteLine(ball.GetLayout());
            p1F1 = false;
            p1F2 = true;
        }
        else if (p1F2)
        {
            Console.WriteLine("OUT! PLAYER 2 WINS!");
            var gameField2 = new GameField();
            Console.WriteLine(gameField2.GetLayout());
            p1F2 = false;
            break;
        }

        if (player1.P1Points <= 0)
        {
            Console.WriteLine("Player1 has no Points to bet. Player2 WINS!");
            break;
        }

        if (player2.P2Points <= 0)
        {
            Console.WriteLine("Player2 has no Points to bet. Player1 WINS!");
            break;
        }
        
    }
    Console.WriteLine(player1.P1Points);
    Console.WriteLine(player2.P2Points);
}
