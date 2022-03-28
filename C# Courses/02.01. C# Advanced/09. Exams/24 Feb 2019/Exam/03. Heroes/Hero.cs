namespace Heroes
{
    using System.Text;
    public class Hero
    {
        private string name;
        private int level;
        private Item item;

        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Hero: {this.Name} - {this.Level}lvl");
            stringBuilder.Append($"{this.Item}");

            return stringBuilder.ToString();
        }
    }
}
