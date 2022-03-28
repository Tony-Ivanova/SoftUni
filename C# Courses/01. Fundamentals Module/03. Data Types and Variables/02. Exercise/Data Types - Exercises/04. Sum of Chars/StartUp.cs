namespace _04._Sum_of_Chars
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var numberOfLines = int.Parse(Console.ReadLine());

            var sum = 0;

            for (int i = 0; i < numberOfLines; i++)
            {
                var letter = char.Parse(Console.ReadLine());

                sum += (int)letter;

            }
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
