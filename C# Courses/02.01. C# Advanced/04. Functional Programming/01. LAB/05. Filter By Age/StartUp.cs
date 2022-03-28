namespace _05._Filter_By_Age
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            static void Main()
            {
                int totalPeople = int.Parse(Console.ReadLine());

                List<Person> people = new List<Person>();

                for (int i = 0; i < totalPeople; i++)
                {
                    string[] currentPerson = Console
                        .ReadLine()
                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    Person person = new Person
                    {
                        Name = currentPerson[0],
                        Age = int.Parse(currentPerson[1])
                    };

                    people.Add(person);
                }

                string conditions = Console.ReadLine();
                int age = int.Parse(Console.ReadLine());

                Func<Person, bool> filteredPredicate;

                if (conditions == "older")
                {
                    filteredPredicate = p => p.Age >= age;
                }
                else
                {
                    filteredPredicate = p => p.Age < age;
                }

                string format = Console.ReadLine();

                Func<Person, string> selectFunc;

                if (format == "name age")
                {
                    selectFunc = p => $"{p.Name} - {p.Age}";
                }
                else
                {
                    selectFunc = p => $"{p.Name}";
                }

                people
                    .Where(filteredPredicate)
                    .Select(selectFunc)
                    .ToList()
                    .ForEach(Console.WriteLine);
            }
        }
    }
}
