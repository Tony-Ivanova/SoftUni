namespace GenericBoxOfString
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                string content = Console.ReadLine();
                Box<string> boxWithString = new Box<string>(content);
                Console.WriteLine(boxWithString.ToString());
            }
        }
    }
}
