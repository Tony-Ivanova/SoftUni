namespace _02._Ascii_Sumator
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string randomString = Console.ReadLine();

            int lowerLimit = Math.Min(firstChar, secondChar);
            int upperLimit = Math.Max(firstChar, secondChar);

            int sum = 0;
 
            for (int i = 0; i < randomString.Length; i++)
            {
                int currentNumber = randomString[i];
                if(currentNumber > lowerLimit && currentNumber < upperLimit)
                {
                    sum += currentNumber;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
