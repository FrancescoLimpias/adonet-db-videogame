using System.Data.SqlClient;

namespace adonet_db_videogame
{
    internal class Program
    {
        //Connection 
        static readonly string connectionParameters = "Data Source=lcalhost;Initial Catalog=adonet-db-videogame;Integrated Security=True";
        internal static readonly SqlConnection SQL = new SqlConnection(connectionParameters);

        static void Main(string[] args)
        {

            //Greet the user
            Console.WriteLine("Welcome to VIDEOGAMES MANAGER!");

            //Attempt connection to database
            try
            {
                SQL.Open();
            }
            catch
            {
                string ERROR = "Unable to connect to database!";
                Console.WriteLine($"[ERR] {ERROR}");
                throw new Exception(ERROR);
            }



            //Close the connection
            SQL.Close();
        }
    }
}