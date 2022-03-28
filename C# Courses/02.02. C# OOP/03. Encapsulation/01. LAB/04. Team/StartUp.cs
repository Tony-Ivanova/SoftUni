namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            var persons = new List<Person>();

            var team = new Team("SoftUni");

            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0],
                                        cmdArgs[1],
                                        int.Parse(cmdArgs[2]),
                                        decimal.Parse(cmdArgs[3]));

                persons.Add(person);
            }

            foreach (Person p in persons)
            {
                team.AddPlayer(p);
            }

            var firstTeam = team.FirstTeam;
            var reserveTeam = team.ReserveTeam;

            Console.WriteLine($"First team has {firstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {reserveTeam.Count} players.");
        }
    }
}
