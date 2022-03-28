namespace _04._Add_Minion
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
            var minionInfo = Console.ReadLine().Split(new[] { " " }, 
                StringSplitOptions.
                RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            var villianInfo = Console.ReadLine().Split(new[] { " " }, 
                StringSplitOptions
                .RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string minionTown = minionInfo[2];

            string villianName = villianInfo[0];

            using (connection)
            {
                connection.Open();

                int? idOfTheTown = GetTownByName(connection, minionTown);

                if (idOfTheTown == null)
                {
                    AddTown(connection, minionTown);
                }

                idOfTheTown = GetTownByName(connection, minionTown);

                AddMinion(connection, minionName, minionAge, idOfTheTown);

                int? ifOfTheVillian = GetVillianByName(connection, villianName);

                if (ifOfTheVillian == null)
                {
                    AddVillian(connection, villianName);
                }

                ifOfTheVillian = GetVillianByName(connection, villianName);

                int ifOfTheMinion = GetMinionByName(connection, minionName);

                AddMinionVillian(connection, ifOfTheVillian, ifOfTheMinion, minionName, villianName);
            }
        }

        private static void AddMinionVillian(SqlConnection connection, int? ifOfTheVillian, int? ifOfTheMinion, string minionName, string villianName)
        {
            using (SqlCommand insertMinionVillian = new SqlCommand(QueryList.insertMinionVillianQuery, connection))
            {
                insertMinionVillian.Parameters.AddWithValue("@villainId", ifOfTheVillian);
                insertMinionVillian.Parameters.AddWithValue("@minionId", ifOfTheMinion);
                insertMinionVillian.ExecuteNonQuery();
            }

            Console.WriteLine($"Successfully added {minionName} to be minion of {villianName}.");
        }

        private static int GetMinionByName(SqlConnection connection, string minionName)
        {
            using (SqlCommand minionSearch = new SqlCommand(QueryList.minionQuery, connection))
            {
                minionSearch.Parameters.AddWithValue("@Name", minionName);
                return (int)minionSearch.ExecuteScalar();
            }
        }

        private static void AddMinion(SqlConnection connection, string minionName, int minionAge, int? idOfTheTown)
        {
            using (SqlCommand insertMinion = new SqlCommand(QueryList.insertMinionQuery, connection))
            {
                insertMinion.Parameters.AddWithValue("@name", minionName);
                insertMinion.Parameters.AddWithValue("@age", minionAge);
                insertMinion.Parameters.AddWithValue("@townId", idOfTheTown);
                insertMinion.ExecuteNonQuery();
            }

            Console.WriteLine($"Minion {minionName} was added to the database.");
        }


        private static int? GetVillianByName(SqlConnection connection, string villianName)
        {
            using (SqlCommand villianSearch = new SqlCommand(QueryList.villianQuery, connection))
            {
                villianSearch.Parameters.AddWithValue("@Name", villianName);

                return (int?)villianSearch.ExecuteScalar();
            }
        }

        private static void AddVillian(SqlConnection connection, string villianName)
        {
            using (SqlCommand insertVillian = new SqlCommand(QueryList.insertVillianQuery, connection))
            {
                insertVillian.Parameters.AddWithValue("@Name", villianName);
                insertVillian.ExecuteNonQuery();
            }

            Console.WriteLine($"Villain {villianName} was added to the database.");
        }

        private static int? GetTownByName(SqlConnection connection, string minionTown)
        {
            using (SqlCommand townSearch = new SqlCommand(QueryList.townQuery, connection))
            {
                townSearch.Parameters.AddWithValue("@townName", minionTown);
                return (int?)townSearch.ExecuteScalar();
            }
        }

        private static void AddTown(SqlConnection connection, string minionTown)
        {
            using (SqlCommand insertTown = new SqlCommand(QueryList.insertTownQuery, connection))
            {
                insertTown.Parameters.AddWithValue("@townName", minionTown);
                insertTown.ExecuteNonQuery();
            }

            Console.WriteLine($"Town {minionTown} was added to the database.");
        }
    }
}
