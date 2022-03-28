namespace _09._Padawan_Equipment
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            double moneyStart = double.Parse(Console.ReadLine());
            int student = int.Parse(Console.ReadLine());
            double lightsaberPerOne = double.Parse(Console.ReadLine());
            double roberPerOne = double.Parse(Console.ReadLine());
            double beltsPerOne = double.Parse(Console.ReadLine());

            int numberOfSabers = (int)Math.Ceiling(student * 1.10);
            int numberOfRobes = student;
            int numberOfBelts = student - (student / 6);

            double moneyNeeded = (lightsaberPerOne * numberOfSabers) + (roberPerOne * numberOfRobes) + (beltsPerOne * numberOfBelts);

            double moneyLeft = moneyStart - moneyNeeded;

            if (moneyLeft >= 0)
            {
                Console.WriteLine($"The money is enough - it would cost {moneyNeeded:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {Math.Abs(moneyLeft):f2}lv more.");
            }
        }
    }
}
