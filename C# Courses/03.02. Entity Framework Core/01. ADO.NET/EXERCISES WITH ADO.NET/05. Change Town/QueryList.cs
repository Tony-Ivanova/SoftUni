namespace _05._Change_Town
{
    public class QueryList
    {
        public const string updateQuery = @"UPDATE Towns
                                    SET Name = UPPER(Name)
                                    WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

        public const string printQuery = @"SELECT t.Name 
                                        FROM Towns as t
                                        JOIN Countries AS c ON c.Id = t.CountryCode
                                        WHERE c.Name = @countryName";
    }
}
