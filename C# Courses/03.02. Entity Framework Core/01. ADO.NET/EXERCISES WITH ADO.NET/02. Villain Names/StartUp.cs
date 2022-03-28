namespace _02._Villain_Names
{
    using System;
    using System.Data.SqlClient;

    class StartUp
    {   
       private static SqlConnection connection = new SqlConnection(Configuration.connectionString);

        static void Main()
        {
            connection.Open();

            using (connection)
            {
                
                SqlCommand commandToFindMoreThan3Minions = new SqlCommand(QueryList.villianWithMoreThan3Minions, connection);

                try
                {
                    SqlDataReader reader = commandToFindMoreThan3Minions.ExecuteReader();

                    using (reader)
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occured while searching for villians with more than 3 minions");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
