namespace PizzaCalories
{
    using System;
    public class Program
    {
        public static void Main()
        {
            try
            {
                var pizzaArgs = Console.ReadLine().Split();
                var pizzaName = pizzaArgs[1];

                var doughArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var typeOfDough = doughArgs[1];
                var bakingTechnique = doughArgs[2];
                var weightDough = double.Parse(doughArgs[3]);

                var dough = new Dough(typeOfDough, bakingTechnique, weightDough);

                var pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    var input = Console.ReadLine();

                    if (input == "END")
                    {
                        break;
                    }

                    var topppingArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var typeOfTopping = topppingArgs[1];
                    var weightTopping = double.Parse(topppingArgs[2]);

                    var topping = new Topping(typeOfTopping, weightTopping);

                    pizza.AddToppings(topping);

                }

                Console.WriteLine($"{pizza.Name} - {pizza.GetTotalCalories().ToString("f2")} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
