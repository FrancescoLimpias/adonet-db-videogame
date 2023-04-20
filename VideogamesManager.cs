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

            using SqlCommand command = new SqlCommand(query, Program.SQL);
            command.Parameters.AddWithValue("@Name", videogameName);

            return command.ExecuteNonQuery() == 1;
        }

        internal static Videogame? SearchById(long id)
        {
            string query = "SELECT * FROM videogames WHERE id = @id";

            using SqlCommand command = new SqlCommand(query, Program.SQL);
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

        internal static List<Videogame> SearchByName(string name)
        {
            List<Videogame> videogames = new List<Videogame>();

            string query = "SELECT * FROM videogames WHERE UPPER(name) LIKE @Name";

            SqlCommand command = new SqlCommand(query, Program.SQL);
            command.Parameters.AddWithValue("@Name", $"%{name.ToUpper()}%");

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                videogames.Add(new Videogame(reader.GetInt64(0), reader.GetString(1)));
            }

            return videogames;
        }

        internal static bool Delete(long id)
        {
            string query = "DELETE FROM videogames WHERE id = @Id";

            using SqlCommand command = new SqlCommand(query, Program.SQL);
            command.Parameters.AddWithValue("@Id", id);

            return command.ExecuteNonQuery() > 0;
        }

        internal static List<Videogame> List()
        {
            List<Videogame> videogames = new();
            string selectionQuery = "SELECT * FROM videogames";

            //Build SQL command
            using SqlCommand command = Program.SQL.CreateCommand();
            command.Connection = Program.SQL;
            command.CommandText = selectionQuery;

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                videogames.Add(new Videogame(reader.GetInt64(0), reader.GetString(1)));
            }

            return videogames;
        }
    }
}
