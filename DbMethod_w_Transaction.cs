using Microsoft.Data.Sqlite;
using Pencil_Tennis.P1;
using Pencil_Tennis.P2;
namespace Pencil_Tennis;

public class DbMethod_w_Transaction
{
    public void CreateTable()
    {
        var sql = @"CREATE TABLE pencil_tennis (
        round INTEGER,
        player1_move INTEGER,
        player2_move INTEGER,
        player1_status INTEGER,
        player2_status INTEGER,
        ball_location INTEGER, 
        )";
        try
        {
            using var connection = new SqliteConnection(@"Data Source=C:\Users\Cheyenne\RiderProjects\Pencil Tennis\db.sqlite");
            connection.Open();
            
            using var command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();
            
            Console.WriteLine("Table created");

        } 
        catch (SqliteException e) 
        {
            Console.WriteLine(e.Message);
        }
    }

    public void InsertNewRoundRow(int BallLocation)
    {
        var gamefield = new GameField();
        var round = gamefield.RoundReturn();
        var player1 = new Player1();
        var player2 = new Player2();
        var player1_status = player1.P1Points;
        var player2_status = player2.P2Points;
        var player1_move = player1.Bet;
        var player2_move = player2.Bet2;
        var ball_location = BallLocation;
        
        try
        {
            using var connection = new SqliteConnection(@"Data Source=C:\Users\Cheyenne\RiderProjects\Pencil Tennis\db.sqlite");
            connection.Open();
    
            using var transaction = connection.BeginTransaction();
            
            try
            {
                var sql = "INSERT INTO pencil_tennis (round, player1_move, player2_move, player1_status, player2_status, ball_location) VALUES(@round, @player1_move, @player2_move, @player1_status, @player2_status, @ball_location)";
                using var cmdInsertRound = new SqliteCommand(sql, connection, transaction);

                cmdInsertRound.Parameters.AddWithValue("@round", round);
                cmdInsertRound.Parameters.AddWithValue("@player1_move", player1_move);
                cmdInsertRound.Parameters.AddWithValue("@player2_move", player2_move);
                cmdInsertRound.Parameters.AddWithValue("@player1_status", player1_status);
                cmdInsertRound.Parameters.AddWithValue("@player2_status", player2_status);
                cmdInsertRound.Parameters.AddWithValue("@ball_location", ball_location);

                cmdInsertRound.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (SqliteException e) {
                transaction.Rollback();
                Console.WriteLine(e.Message);
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
