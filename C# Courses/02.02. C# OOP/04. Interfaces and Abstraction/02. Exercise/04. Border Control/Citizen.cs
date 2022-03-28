namespace BorderControl
{
    public class Citizen : IIdentification
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public int Age { get; set; }
        public string Name { get; set; }
        public string Id { get; private set; }
    }
}
