namespace _02._Oldest_Family_Member
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private List<Person> people = new List<Person>();

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.people.OrderByDescending(x => x.Age).FirstOrDefault();
        }
    }

    public class Person
    {        
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        
        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }

    public class StartUp
    {
        public static void Main()
        {
            int memberCount = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < memberCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
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
