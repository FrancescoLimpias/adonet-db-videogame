using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    internal static class VideogamesManager
    {
        internal static bool Insert(string videogameName)
        {
            string query = "INSERT INTO videogames VALUES (@Name)";

            SqlCommand command = new SqlCommand(query, Program.SQL);
            command.Parameters.AddWithValue("@Name", videogameName);

            return command.ExecuteNonQuery() == 1;
        }

        internal static Videogame? SearchById(long id)
        {
            string query = "SELECT * FROM videogames WHERE id = @id";

            SqlCommand command = new SqlCommand(query, Program.SQL);
            command.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new Videogame(reader.GetInt64(0), reader.GetString(1));
            }
            else
            {
                return null;
            }
        }

        static void firstTest()
        {

            string selectionQuery = "SELECT * FROM videogames";

            //Build SQL command
            using SqlCommand command = Program.SQL.CreateCommand();
            command.Connection = Program.SQL;
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
