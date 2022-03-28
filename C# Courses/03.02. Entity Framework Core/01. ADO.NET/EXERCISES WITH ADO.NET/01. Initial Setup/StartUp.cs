namespace _01._Initial_Setup
{
    using System;
    using System.Data.SqlClient;

    class StartUp
    {
        private static string connectionString = "Server=.;" +
                                                     "Database={0};" +
                                                     "Integrated Security=true";

        private const string DB_Name = "MinionsDB";

        public static void Main()
        {
            SqlConnection connection = new SqlConnection(String.Format(connectionString, "master"));

            connection.Open();

            using (connection)
            {                
                SqlCommand createDbCommand = new SqlCommand(QueryList.createDatabase, connection);

                try
                {
                    createDbCommand.ExecuteNonQuery();
                    Console.WriteLine("Database created successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was error creating database!");
                    Console.WriteLine($"{ex.Message}");
                    return;
                }
            }

            connection = new SqlConnection(String.Format(connectionString, DB_Name));

            connection.Open();

            using (connection)
            {                
                SqlCommand commandCreateTable = new SqlCommand(QueryList.createTables, connection);                              

                SqlCommand insertIntoTable = new SqlCommand(QueryList.insertTables, connection);

                try
                {
                    commandCreateTable.ExecuteNonQuery();
                    Console.WriteLine("The table was created successfully!");
                    insertIntoTable.ExecuteNonQuery();
                    Console.WriteLine("The information was inserted into the table!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an error processing your request!");
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
