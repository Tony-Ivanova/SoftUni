namespace _10._Lower_or_Upper
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var characterToCheck = char.Parse(Console.ReadLine());

            if (char.IsUpper(characterToCheck))
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
