namespace _02._English_Name_of_the_Last_Digit
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var number = Console.ReadLine();

            var lastChar = number.Last();
            var lastNumber = int.Parse(lastChar.ToString());

            var result = string.Empty;

            switch (lastNumber)
            {
                case 1:
                    result = "one";
                    break;
                case 2:
                    result = "two";
                    break;
                case 3:
                    result = "three";
                    break;
                case 4:
                    result = "four";
                    break;
                case 5:
                    result = "five";
                    break;
                case 6:
                    result = "six";
                    break;
                case 7:
                    result = "seven";
                    break;
                case 8:
                    result = "eight";
                    break;
                case 9:
                    result = "nine";
                    break;
                case 10:
                    result = "ten";
                    break;
                case 0:
                    result = "zero";
                    break;
            }
            Console.WriteLine(result);
        }
    }
}
