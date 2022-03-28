namespace _01._Data_Types
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string type = Console.ReadLine();
            int numberInt = 0;
            double numberDouble = 0;
            string text = string.Empty;

            switch (type)
            {
                case "int":
                    Integer(numberInt);
                    break;
                case "real":
                    Double(numberDouble);
                    break;
                case "string":
                    TextMethod(text);
                    break;
            }
        }
        private static void Integer(int numberInt)
        {
            numberInt = int.Parse(Console.ReadLine());
            Console.WriteLine(numberInt * 2);
        }
        private static void Double(double numberDouble)
        {
            numberDouble = double.Parse(Console.ReadLine());
            Console.WriteLine($"{(numberDouble * 1.5):f2}");
        }
        private static void TextMethod(string text)
        {
            text = Console.ReadLine();
            Console.WriteLine($"${text}$");
        }
    }
}