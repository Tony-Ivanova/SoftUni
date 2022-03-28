namespace DefiningClasses
{
    using System;
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

            Person olderstMember = family.GetOldestMember();

            Console.WriteLine(olderstMember);
        }
    }
}
