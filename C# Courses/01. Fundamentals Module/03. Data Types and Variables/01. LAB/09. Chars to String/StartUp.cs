namespace _09._Chars_to_String
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char thirdChar = char.Parse(Console.ReadLine());

            string text = $"{firstChar}{secondChar}{thirdChar}";
            Console.WriteLine(text);
        }
    }
}
