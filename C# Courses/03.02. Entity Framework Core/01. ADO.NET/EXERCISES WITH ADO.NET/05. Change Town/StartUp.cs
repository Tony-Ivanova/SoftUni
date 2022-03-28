namespace _05._Change_Town
{
    using _02._Villain_Names;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    class StartUp
    {
        private static SqlConnection connection = new SqlConnection(Configuration.connectionString);

        static void Main()
        {
            string nameOfTheCountry = Console.ReadLine();

            connection.Open();

            using (connection)
            {                
                SqlCommand updateCommand = new SqlCommand(QueryList.updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@countryName", nameOfTheCountry);
                int count = (int)updateCommand.ExecuteNonQuery();

                if (count == 0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    SqlCommand printCommand = new SqlCommand(QueryList.printQuery, connection);
                    printCommand.Parameters.AddWithValue("@countryName", nameOfTheCountry);
                    printCommand.ExecuteNonQuery();                    

                    var cities = new List<string>();

                    SqlDataReader reader = printCommand.ExecuteReader();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            cities.Add((string)reader[0]);
                        }
                    }

                    Console.WriteLine($"{count} town names were affected.");
                    Console.WriteLine(string.Join(", ", cities));
                }
            }
        }
    }
}
