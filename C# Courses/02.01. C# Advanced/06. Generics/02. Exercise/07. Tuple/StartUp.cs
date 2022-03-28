namespace Tuple
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var firstInput = Console.ReadLine().Split();

            string name = firstInput[0] + " " + firstInput[1];
            string address = firstInput[2];

            Tuple<string, string> firstTuple = new Tuple<string, string>(name, address);



            var secondInput = Console.ReadLine().Split();
            string secondName = secondInput[0];
            int liters = int.Parse(secondInput[1]);

            Tuple<string, int> secondTulpe = new Tuple<string, int>(secondName, liters);

            var thirdInput = Console.ReadLine().Split();

            int intNumber = int.Parse(thirdInput[0]);
            double doubleNumber = double.Parse(thirdInput[1]);

            Tuple<int, double> thirdTulpe = new Tuple<int, double>(intNumber, doubleNumber);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTulpe);
            Console.WriteLine(thirdTulpe);
        }
    }
}
