namespace _04._Array_Rotation
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rotate = int.Parse(Console.ReadLine());

            for (int j = 0; j < rotate; j++)
            {
                int first = elements[0];

                for (int i = 1; i < elements.Length; i++)
                {
                    elements[i - 1] = elements[i];
                }

                elements[elements.Length - 1] = first;
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
