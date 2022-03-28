namespace _03._Minion_Names
{
    using _02._Villain_Names;
    using System;
    using System.Data.SqlClient;

    class StartUp
    {
        private static SqlConnection connection = new SqlConnection(Configuration.connectionString);

        static void Main()
        {
            int villianId = int.Parse(Console.ReadLine());

            connection.Open();

            using (connection)
            {
                SqlCommand villianSearch = new SqlCommand(QueryList.villianQuery, connection);
                villianSearch.Parameters.AddWithValue("@Id", villianId);
                string villianName = (string)villianSearch.ExecuteScalar();                            
             
                SqlCommand minionSearch = new SqlCommand(QueryList.minionsQuery, connection);
                minionSearch.Parameters.AddWithValue("@Id", villianId);
                SqlDataReader minionReader = minionSearch.ExecuteReader();

                try
                {
                    if (villianName == null)
                    {
                        Console.WriteLine($"No villain with ID {villianId} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {villianName}");

                    while (minionReader.Read())
                    {
                        long rowNumber = (long)minionReader[0];
                        string name = (string)minionReader[1];
                        int age = (int)minionReader[2];

                        Console.WriteLine($"{rowNumber}. {name} {age}");
                    }

                    if (!minionReader.HasRows)
                    {
                        Console.WriteLine("(no minions)");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);  
                }
            }
        }
    }
}
