namespace _07._Concat_Names
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            string delimeter = Console.ReadLine();

            string finalPrint = firstName + delimeter + secondName;
            Console.WriteLine(finalPrint);
        }
    }
}
