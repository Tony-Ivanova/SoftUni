namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int memberCount = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < memberCount; i++)
            {
                string[] tokens = Console.ReadLine()
                                         .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            List<Person> peopleOver30 = family
                .GetPeopleOver30()
                .OrderBy(x => x.Name)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, peopleOver30));

        }
    }
}
