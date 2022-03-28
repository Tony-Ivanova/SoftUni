namespace _07._Print_All_Minion_Names
{
    using _02._Villain_Names;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
   
    class StartUp
    {
        private static SqlConnection connection = new SqlConnection(Configuration.connectionString);

        static void Main(string[] args)
        {
            var namesOfMinions = new List<string>();

            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand(QueryList.minionNameQuery, connection);

                SqlDataReader reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        namesOfMinions.Add((string)reader[0]);
                    }
                }

                Console.WriteLine("Original Order");
                Console.WriteLine(string.Join(Environment.NewLine, namesOfMinions));
                Console.WriteLine();

                Console.WriteLine("Output");

                for (int i = 0; i < namesOfMinions.Count; i++)
                {
                    string currentFirstNameFromLast = namesOfMinions[i];
                    string currentSecondNameFromList = namesOfMinions[namesOfMinions.Count - 1];
                    namesOfMinions.RemoveAt(namesOfMinions.Count - 1);

                    Console.WriteLine(currentFirstNameFromLast);

                    if (i == namesOfMinions.Count)
                    {
                        break;
                    }

                    Console.WriteLine(currentSecondNameFromList);
                }


                //Whichever floats your goat:

                //while (true)
                //{
                //    string currentFirstNameFromLast = namesOfMinions.First();
                //    namesOfMinions.RemoveAt(0);
                //    Console.WriteLine(currentFirstNameFromLast);

                //    if (namesOfMinions.Count == 0)
                //    {
                //        break;
                //    }

                //    string currentSecondNameFromList = namesOfMinions.Last();
                //    namesOfMinions.RemoveAt(namesOfMinions.Count - 1);
                //    Console.WriteLine(currentSecondNameFromList);

                //}

            }
        }
    }
}

