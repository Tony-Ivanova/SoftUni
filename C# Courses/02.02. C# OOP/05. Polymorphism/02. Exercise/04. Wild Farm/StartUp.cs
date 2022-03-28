namespace _04._Wild_Farm
{
    using _04._Wild_Farm.Models.Animals;
    using _04._Wild_Farm.Models.Foods;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {

            string input = Console.ReadLine();

            var animals = new List<Animal>();

            while (input != "End")
            {
                var animalArgs = input.Split();

                var animal = AnimalFactory.Create(animalArgs);

                var foodArgs = Console.ReadLine().Split();

                var food = FoodFactory.Create(foodArgs);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}