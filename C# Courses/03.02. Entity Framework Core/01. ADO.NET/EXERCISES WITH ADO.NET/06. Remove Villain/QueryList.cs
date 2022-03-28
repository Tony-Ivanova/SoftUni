namespace _06._Remove_Villain
{
    public class QueryList
    {
        public const string villianQuery = "SELECT Name FROM Villains WHERE Id = @villainId";

        public const string deleteFromMinionsVillains = "DELETE FROM MinionsVillains " +
                                                        "WHERE VillainId = @villainId";

        public const string deleteFromVillains = @"DELETE FROM Villains
                                                 WHERE Id = @villainId";

    }
}
