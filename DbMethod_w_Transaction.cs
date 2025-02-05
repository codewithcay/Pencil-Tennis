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

    public void AddData(List<int> moves, int player1_status, int player2_status, int player2_move, int player1_move,
            int ball_location, int round, int winner)
        {
            try
            {
                using var connection =
                    new SqliteConnection(@"Data Source=C:\Users\Cheyenne\RiderProjects\Pencil Tennis\db.sqlite");
                connection.Open();

                // Check if a record for this round already exists
                var checkCommand = new SqliteCommand(
                    "SELECT COUNT(*) FROM pencil_tennis WHERE round = @round", connection);
                checkCommand.Parameters.AddWithValue("@round", round);
                var existingRecordCount = (long)checkCommand.ExecuteScalar();

                // If a record exists and Player 1 is the winner, update the record
                if (existingRecordCount > 0 && winner == 1)
                {
                    var updateCommand = new SqliteCommand(
                        "UPDATE pencil_tennis SET player1_move = @player1_move, player2_move = @player2_move, " +
                        "player1_status = @player1_status, player2_status = @player2_status, ball_location = @ball_location, " +
                        "rating = @rating WHERE round = @round", connection);

                    updateCommand.Parameters.AddWithValue("@round", round);
                    updateCommand.Parameters.AddWithValue("@player1_move", player1_move);
                    updateCommand.Parameters.AddWithValue("@player2_move", player2_move);
                    updateCommand.Parameters.AddWithValue("@player1_status", player1_status);
                    updateCommand.Parameters.AddWithValue("@player2_status", player2_status);
                    updateCommand.Parameters.AddWithValue("@ball_location", ball_location);
                    updateCommand.Parameters.AddWithValue("@rating", 1); // or any other logic for rating

                    updateCommand.ExecuteNonQuery();
                }
                else if (existingRecordCount == 0) // If no existing record, insert a new one
                {
                    var gamefield = new GameField { Round = round };
                    var player1 = new Player1 { P1Points = player1_status, Bet = 0 };
                    var player2 = new Player2 { P2Points = player2_status, Bet2 = player2_move };
                    var ratingMove = new RatingMove { ratingplayer = 1 };

                    InsertNewRoundRow(ball_location, gamefield, player1, player2, ratingMove,player1_move,
                        player2_move);
                }

                connection.Close();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
