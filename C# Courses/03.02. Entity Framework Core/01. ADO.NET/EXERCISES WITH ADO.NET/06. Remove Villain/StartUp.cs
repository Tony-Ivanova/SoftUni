namespace _06._Remove_Villain
{
    using _02._Villain_Names;
    using System;
    using System.Data.SqlClient;

    class StartUp
    {
        private static SqlConnection connection = new SqlConnection(Configuration.connectionString);

        private static SqlTransaction transaction;

        private static SqlCommand command = new SqlCommand();

        static void Main()
        {
            int villainId = int.Parse(Console.ReadLine());
            string villainName;

            connection.Open();

            using (connection)
            {
                transaction = connection.BeginTransaction();

                try
                {
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandText = QueryList.villianQuery;
                    command.Parameters.AddWithValue("@villainId", villainId);

                    villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        throw new ArgumentException("No such villain was found");
                    }

                    int affectedRows = DeleteMinionsVillainById(villainId, connection, transaction);
                    DeleteVillainById(villainId, connection, transaction);

                    transaction.Commit();

                    Console.WriteLine($"{villainName} was deleted.");
                    Console.WriteLine($"{affectedRows} minions were released.");
                }
                catch (ArgumentException ae)
                {
                    try
                    {
                        Console.WriteLine(ae.Message);
                        transaction.Rollback();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                catch (Exception e)
                {
                    try
                    {
                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                    catch (Exception re)
                    {
                        Console.WriteLine(re.Message);
                    }
                }
            }
        }

        private static void DeleteVillainById(int villainId, SqlConnection connection, SqlTransaction transaction)
        {
            command.CommandText = QueryList.deleteFromVillains;            
            command.ExecuteNonQuery();
        }

        private static int DeleteMinionsVillainById(int villainId, SqlConnection connection, SqlTransaction transaction)
        {
            command.CommandText = QueryList.deleteFromMinionsVillains;          
            return command.ExecuteNonQuery();
        }
    }
}
