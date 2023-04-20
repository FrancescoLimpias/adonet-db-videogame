using System.Data.SqlClient;

namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionParameters = "Data Source=localhost;Initial Catalog=adonet-db-videogame;Integrated Security=True";

            //Greet the user
            Console.WriteLine("Welcome to VIDEOGAMES MANAGER!");

            using SqlConnection SQL = new SqlConnection(connectionParameters);

            //Attempt connection to database
            try
            {
                SQL.Open();
            }
            catch
            {
                Console.WriteLine("[ERR] Unable to connect to database!");
            }

            string selectionQuery = "SELECT * FROM videogames";

            //Build SQL command
            using SqlCommand command = SQL.CreateCommand();
            command.Connection = SQL;
            command.CommandText = selectionQuery;

            //Attempt command execution
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                        $"ID: {reader.GetInt64(0)}\r\n"
                        + $"Name: {reader.GetString(1)}\r\n"
                        + "--------------------\r\n\r\n"
                        );
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERR] " + e.Message);
            }
        }
    }
}