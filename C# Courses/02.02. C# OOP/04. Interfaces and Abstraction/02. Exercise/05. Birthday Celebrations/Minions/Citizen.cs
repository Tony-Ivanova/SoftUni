namespace BirthdayCelebrations
{
    using BirthdayCelebrations.Interfaces;
    public class Citizen : IIdentification, IBirthday, IName
    {

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public int Age { get; set; }

        public string Id { get; private set; }

        public string Birthday { get; private set; }

        public string Name { get; private set; }
    }
}
