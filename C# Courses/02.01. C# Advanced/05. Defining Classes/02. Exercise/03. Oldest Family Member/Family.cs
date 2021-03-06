namespace DefiningClasses
{
    using System.Linq;
    using System.Collections.Generic;

    public class Family
    {
        private List<Person> people = new List<Person>();

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.people
                       .OrderByDescending(x => x.Age)
                       .FirstOrDefault();
        }
    }
}
