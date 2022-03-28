namespace _05._Bomb_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int[] bombNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray(); 

            int bombNumber = bombNumbers[0];
            int range = bombNumbers[1];

            int bombIndex = numbers.IndexOf(bombNumber);

            while (bombIndex != -1)
            {
                int leftIndex = (bombIndex - range) < 0 ? 0 : bombIndex - range; 
                int rightIndex = (bombIndex + range) > (numbers.Count - 1) ? numbers.Count - 1 : bombIndex + range; 

                int count = rightIndex - leftIndex + 1; 

                numbers.RemoveRange(leftIndex, count);
                bombIndex = numbers.IndexOf(bombNumber);
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
