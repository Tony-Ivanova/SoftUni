namespace _09._Increase_Age_Stored_Procedure
{
    public class QueryList
    {
        public const string createProcedure = @"CREATE PROC usp_GetOlder @id INT
                                                AS
                                                UPDATE Minions
                                                SET Age += 1
                                                WHERE Id = @id";

        public const string selectNameAndAgeOfMinions = @"SELECT Name, Age FROM Minions WHERE Id = @Id";

        public const string deleteProcedure = @"DROP PROC usp_GetOlder";
    }
}
