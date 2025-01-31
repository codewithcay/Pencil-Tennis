using Microsoft.Data.Sqlite;
using Pencil_Tennis.P1;
using Pencil_Tennis.P2;
namespace Pencil_Tennis;

public class DbMethod_w_Transaction
{
    public void CreateTable()
    {
        var sql = @"CREATE TABLE IF NOT EXISTS pencil_tennis (
        round INTEGER,
        player1_move INTEGER,
        player2_move INTEGER,
        player1_status INTEGER,
        player2_status INTEGER,
        ball_location INTEGER,
        rating INTEGER
        )";
        try
        {
            using var connection =
                new SqliteConnection(@"Data Source=C:\Users\Cheyenne\RiderProjects\Pencil Tennis\db.sqlite");
            connection.Open();

            using var command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();

        }
        catch (SqliteException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void InsertNewRoundRow(int BallLocation, GameField gamefield, Player1 player1, Player2 player2, RatingMove ratingMove)
    {
        var round = gamefield.Round;
        var player1_status = player1.P1Points;
        var player2_status = player2.P2Points;
        var player1_move = player1.Bet;
        var player2_move = player2.Bet2;
        var ball_location = BallLocation;
        var rating = ratingMove.ratingplayer1;

        try
        {
            using var connection =
                new SqliteConnection(@"Data Source=C:\Users\Cheyenne\RiderProjects\Pencil Tennis\db.sqlite");
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                var sql =
                    "INSERT INTO pencil_tennis (round, player1_move, player2_move, player1_status, player2_status, ball_location, rating) VALUES(@round, @player1_move, @player2_move, @player1_status, @player2_status, @ball_location, @rating)";
                using var cmdInsertRound = new SqliteCommand(sql, connection, transaction);

                cmdInsertRound.Parameters.AddWithValue("@round", round);
                cmdInsertRound.Parameters.AddWithValue("@player1_move", player1_move);
                cmdInsertRound.Parameters.AddWithValue("@player2_move", player2_move);
                cmdInsertRound.Parameters.AddWithValue("@player1_status", player1_status);
                cmdInsertRound.Parameters.AddWithValue("@player2_status", player2_status);
                cmdInsertRound.Parameters.AddWithValue("@ball_location", ball_location);
                cmdInsertRound.Parameters.AddWithValue("@rating", rating);
                cmdInsertRound.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (SqliteException e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
            }
        }
        catch (SqliteException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    public void SetRatings(int winner)
    {
        if (winner == 1)
        {
            var sql = @"UPDATE pencil_tennis SET rating = SUM(rating, 1) WHERE rating = 0";
            try
            {
                using var connection =
                    new SqliteConnection(@"Data Source=C:\Users\Cheyenne\RiderProjects\Pencil Tennis\db.sqlite");
                connection.Open();
                using var command = new SqliteCommand(sql, connection);
                var rowInserted = command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
}
