namespace FoodShortage
{
    using FoodShortage.Interfaces;
    public class Pet : IBirthday
    {
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
        public string Name { get; private set; }

        public string Birthday { get; private set; }
    }
}
