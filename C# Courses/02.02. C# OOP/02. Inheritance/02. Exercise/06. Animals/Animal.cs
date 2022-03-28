namespace Animals
{
    using System;
    using System.Text;
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                IsValidString(value);
                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }

        public string Gender
        {
            get => this.gender;
            private set
            {
                IsValidString(value);
                this.gender = value;
            }
        }

        private void IsValidString(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
        }

        public virtual string ProduceSound()
        {
            return base.ToString();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{this.GetType().Name}");
            builder.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            builder.Append($"{this.ProduceSound()}");

            return builder.ToString();
        }
    }
}
