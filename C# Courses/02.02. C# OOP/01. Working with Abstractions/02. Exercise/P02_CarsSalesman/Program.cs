namespace P02_CarsSalesman
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            CarFactory carFactory = new CarFactory();
            EngineFactory engineFactory = new EngineFactory();

            Salesman salesman = new Salesman(carFactory, engineFactory);

            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                salesman.AddEngine(parameters);
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                salesman.AddCar(parameters);

            }

            foreach (var car in salesman.GetCars())
            {
                Console.WriteLine(car);
            }
        }
    }
}
