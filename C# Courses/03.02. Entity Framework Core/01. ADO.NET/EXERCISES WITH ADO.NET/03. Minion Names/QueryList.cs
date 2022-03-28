namespace _03._Minion_Names
{
    public class QueryList
    {
        public const string villianQuery = "SELECT Name FROM Villains WHERE Id = @Id";

        public const string minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";
    }
}
