namespace _01._Data_Type_Finder
{
    using System;
    using System.Numerics;

    public class StartUp
    {
        public static void Main()
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "END")
                {
                    break;
                }
                bool isInteger = BigInteger.TryParse(line, out BigInteger result);
                bool isBoolen = bool.TryParse(line, out bool result1);
                bool isDecimal = double.TryParse(line, out double result2);
                bool isCharacter = char.TryParse(line, out char result3);


                if (isInteger)
                {
                    Console.WriteLine($"{line} is integer type");
                }
                else if (isDecimal)
                {
                    Console.WriteLine($"{line} is floating point type");
                }
                else if (isCharacter)
                {
                    Console.WriteLine($"{line} is character type");
                }
                else if (isBoolen)
                {
                    Console.WriteLine($"{line} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{line} is string type");
                }
            }
        }
    }
}
