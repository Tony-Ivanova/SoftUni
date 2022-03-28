namespace _07._String_Explosion
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int strength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char symbol = input[i];

                if (symbol == '>')
                {
                    strength += int.Parse(input[i + 1].ToString());
                }

                if (strength > 0)
                {
                    input = input.Remove(i, 1);
                    i--;
                    strength--;
                }
            }

            Console.WriteLine(input);
        }
    }
}
