namespace _8._Increase_Minion_Age
{
    public class QueryList
    {
        public const string updateMinion = @"UPDATE Minions
                                            SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                            WHERE Id = @Id";

        public const string selectNameANdAge = @"SELECT Name, Age FROM Minions";
    }
}
