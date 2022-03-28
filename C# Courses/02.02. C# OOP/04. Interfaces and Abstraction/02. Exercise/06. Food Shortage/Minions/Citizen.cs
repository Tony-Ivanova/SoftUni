namespace FoodShortage
{
    using FoodShortage.Interfaces;
    public class Citizen : IIdentification, IBirthday, IBuyer
    {
        private const int food = 0;

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
            this.Food = food;
        }

        public string Id { get; private set; }

        public string Birthday { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int BuyFood()
        {
            return this.Food += 10;
        }

        public int Food { get; private set; }
    }
}
