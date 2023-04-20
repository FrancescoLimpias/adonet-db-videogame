using System.Data.SqlClient;

namespace adonet_db_videogame
{
    internal class Program
    {
        //Connection 
        static readonly string connectionParameters = "Data Source=localhost;Initial Catalog=adonet-db-videogame;Integrated Security=True";
        internal static readonly SqlConnection SQL = new SqlConnection(connectionParameters);

        //Operations
        enum Operation
        {
            INSERT
        }

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


            //Ask for operation to perform
            Console.WriteLine("\r\nWhich operation would you like to do?");
            foreach (Operation operationName in Enum.GetValues(typeof(Operation)))
            {
                Console.WriteLine($" - {operationName}");
            }
            Console.Write("\r\noperation: ");
            Operation operation = UConsole.AskStringToCast<Operation>(
                (input) =>
                {
                    return Enum.Parse<Operation>(input);
                });


            //Operation SWITCH
            switch (operation)
            {
                case Operation.INSERT:

                    Console.Write("Insert a name: ");

                    //Attempt insertion and store result
                    bool success = VideogamesManager.Insert(UConsole.AskString());

                    Console.WriteLine(
                        success ?
                        "Videogame added."
                        : "Error!"
                        );

                    break;
            }


            //Close the connection
            SQL.Close();
        }
    }
}