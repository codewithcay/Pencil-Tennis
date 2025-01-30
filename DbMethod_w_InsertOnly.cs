using Microsoft.Data.Sqlite;
using Pencil_Tennis.P1;
using Pencil_Tennis.P2;

namespace Pencil_Tennis;

public class DbMethod_w_InsertOnly
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

    public void InsertRoundCount()
    {
        var sql = @"INSERT INTO pencil_tennis(round)" + "VALUES(@round)";
        var gamefield = new GameField();
        var round = gamefield.RoundReturn();
        
        try
        {
            using var connection = new SqliteConnection(@"Data Source=C:\Users\Cheyenne\RiderProjects\Pencil Tennis\db.sqlite");
            connection.Open();
            
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@round", round);
            
            var rowInserted = command.ExecuteNonQuery();


        } 
        catch (SqliteException e) 
        {
            Console.WriteLine(e.Message);
        }
    }

    public void InsertPlayerPoints()
    {
        var sql = @"INSERT INTO pencil_tennis (player1_status, player2_status)" + "VALUES (@player1_status, @player2_status)";
        var player1 = new Player1();
        var player2 = new Player2();
        var player1_status = player1.P1Points;
        var player2_status = player2.P2Points;
        
        try
        {
            using var connection = new SqliteConnection(@"Data Source=C:\Users\Cheyenne\RiderProjects\Pencil Tennis\db.sqlite");
            connection.Open();
            
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@player1_status", player1_status);
            command.Parameters.AddWithValue("@player2_status", player2_status);
            
            var rowInserted = command.ExecuteNonQuery();


        } 
        catch (SqliteException e) 
        {
            Console.WriteLine(e.Message);
        }
    }

    public void InsertPlayerMove()
    {
        var sql = @"INSERT INTO pencil_tennis (player1_move, player2_move)" + "VALUES (@player1_move, @player2_move)";
        var player1 = new Player1();
        var player2 = new Player2();
        var player1_move = player1.Bet;
        var player2_move = player2.Bet2;
        
        try
        {
            using var connection = new SqliteConnection(@"Data Source=C:\Users\Cheyenne\RiderProjects\Pencil Tennis\db.sqlite");
            connection.Open();
            
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@player1_move", player1_move);
            command.Parameters.AddWithValue("@player2_move", player2_move);
            
            var rowInserted = command.ExecuteNonQuery();


        } 
        catch (SqliteException e) 
        {
            Console.WriteLine(e.Message);
        }
    }

    public void InsertBallLocation(int BallLocation)
    {
        var sql = @"INSERT INTO pencil_tennis (ball_location)" + "VALUES(@ball_location)";
        var ball_location = BallLocation;
        
        try
        {
            using var connection = new SqliteConnection(@"Data Source=C:\Users\Cheyenne\RiderProjects\Pencil Tennis\db.sqlite");
            connection.Open();
            
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@ball_location", ball_location);
            
            var rowInserted = command.ExecuteNonQuery();


        } 
        catch (SqliteException e) 
        {
            Console.WriteLine(e.Message);
        }
    }
}
