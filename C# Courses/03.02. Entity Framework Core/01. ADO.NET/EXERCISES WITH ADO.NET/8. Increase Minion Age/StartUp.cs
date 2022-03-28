namespace _8._Increase_Minion_Age
{
    using _02._Villain_Names;
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    class StartUp
    {
        private static SqlConnection connection = new SqlConnection(Configuration.connectionString);

        static void Main()
        {
            var inputMinionIds = Console.ReadLine().Split(new char[] { ' ' }, 
                StringSplitOptions
                .RemoveEmptyEntries);

            connection.Open();

            using (connection)
            {
                SqlCommand updateMinions = new SqlCommand(QueryList.updateMinion, connection);

                for (int i = 0; i < inputMinionIds.Length; i++)
                {
                    updateMinions.Parameters.AddWithValue("@Id", inputMinionIds[i]);
                    updateMinions.ExecuteNonQuery();
                    updateMinions.Parameters.Clear();
                }

                SqlCommand printMinions = new SqlCommand(QueryList.selectNameANdAge, connection);
                SqlDataReader reader = printMinions.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string nameOfMinion = (string)reader[0];
                        int ageOfMinion = (int)reader[1];

                        Console.WriteLine($"{nameOfMinion} {ageOfMinion}");
                    }
                }
            }
        }
    }
}
