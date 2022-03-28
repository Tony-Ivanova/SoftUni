namespace Animals
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string input = Console.ReadLine();

            while (input != "Beast!")
            {

                string[] animalInfo = Console.ReadLine()
                                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = animalInfo[2];

                try
                {
                    if (input == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        animals.Add(dog);
                    }
                    else if (input == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);
                    }
                    else if (input == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        animals.Add(frog);
                    }
                    else if (input == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.Add(tomcat);
                    }
                    else if (input == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        animals.Add(kitten);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            animals.ForEach(Console.WriteLine);
        }
    }
}
