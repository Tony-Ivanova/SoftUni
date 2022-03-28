namespace GenericSwapMethodString
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int lineCount = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < lineCount; i++)
            {
                string line = Console.ReadLine();
                box.Add(line);
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            box.Swap(firstIndex, secondIndex);

            Console.WriteLine(box);
        }
    }
}
