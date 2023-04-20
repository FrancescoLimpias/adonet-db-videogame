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
            INSERT,
            SEARCHID,
            EXIT
        }

        static void Main(string[] args)
        {

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

            //Ask user for a prompt
            while (true)
                AskPrompt();
        }

        //Show Prompt video
        static void AskPrompt()
        {
            Console.Clear();

            //Greet the user
            Console.WriteLine("Welcome to VIDEOGAMES MANAGER!");

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
            Console.WriteLine();


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
                case Operation.SEARCHID:

                    Console.Write("Insert an ID: ");
                    Videogame? videogame = VideogamesManager.SearchById(UConsole.AskLong());

                    if (videogame != null)
                    {
                        Console.WriteLine($"[FOUND] Name: {videogame.Name}");
                    }
                    else
                    {
                        Console.WriteLine("[NOT FOUND] No videogame for the given ID");
                    }
                    break;
                case Operation.EXIT:

                    //Close SQL Connection
                    SQL.Close();

                    //Bye to user, wait for the user to read the message
                    Console.WriteLine("\r\n\r\nBye!");
                    System.Threading.Thread.Sleep(1000);

                    //EXIT
                    System.Environment.Exit(0);
                    break;
            }

            //Wait before restarting window
            Console.WriteLine("\r\nRestarting terminal in 3 seconds...");
            System.Threading.Thread.Sleep(3000);
        }
    }
}