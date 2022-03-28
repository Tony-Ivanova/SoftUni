namespace GenericBoxOfInteger
{
    using System;
    class StartUp
    {
        public static void Main()
        {
            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                int content = int.Parse(Console.ReadLine());
                Box<int> boxWithInts = new Box<int>(content);
                Console.WriteLine(boxWithInts.ToString());
            }
        }
    }
}
