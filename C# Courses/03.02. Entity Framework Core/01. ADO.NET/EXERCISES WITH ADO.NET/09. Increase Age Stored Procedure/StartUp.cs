namespace _09._Increase_Age_Stored_Procedure
{
    using _02._Villain_Names;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    class StartUp
    {
        private static SqlConnection connection = new SqlConnection(Configuration.connectionString);

        static void Main()
        {
            int minionId = int.Parse(Console.ReadLine());

            connection.Open();

            using (connection)
            {
                using (SqlCommand createProcedure = new SqlCommand(QueryList.createProcedure, connection))
                {
                    createProcedure.ExecuteNonQuery();
                }

                using (SqlCommand updateMinions = new SqlCommand("usp_GetOlder", connection))
                {
                    updateMinions.CommandType = CommandType.StoredProcedure;
                    updateMinions.Parameters.AddWithValue("@Id", minionId);
                    updateMinions.ExecuteNonQuery();
                }

                using (SqlCommand printMinions = new SqlCommand(QueryList.selectNameAndAgeOfMinions, connection))
                {
                    printMinions.Parameters.AddWithValue("@Id", minionId);
                    SqlDataReader reader = printMinions.ExecuteReader();
                 
                    using (reader)
                    {
                        while (reader.Read())
                        {
                            string nameOfMinion = (string)reader[0];
                            int ageOfMinion = (int)reader[1];

                            Console.WriteLine($"{nameOfMinion} - {ageOfMinion} years old");
                        }
                    }
                }

                using(SqlCommand dropProcedure = new SqlCommand(QueryList.deleteProcedure, connection))
                {
                    dropProcedure.ExecuteNonQuery();
                }
            }
        }
    }
}
