namespace _04._Add_Minion
{
    public class QueryList
    {
        public const string insertMinionVillianQuery = "INSERT INTO MinionsVillains(MinionId, VillainId) VALUES(@villainId, @minionId)";
        public const string minionQuery = "SELECT Id FROM Minions WHERE Name = @Name";
        public const string insertVillianQuery = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@Name, 4)";
        public const string villianQuery = "SELECT Id FROM Villains WHERE Name = @Name";
        public const string insertMinionQuery = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
        public const string insertTownQuery = "INSERT INTO Towns (Name) VALUES (@townName)";
        public const string townQuery = "SELECT Id FROM Towns WHERE Name = @townName";
    }
}
