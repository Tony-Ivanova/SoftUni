namespace _04._Cups_and_Bottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var cups = Console.ReadLine()
                              .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse)
                              .ToList();

            var bottles = Console.ReadLine()
                                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToList();

            var stackBottles = new Stack<int>(bottles);
            var queCups = new Queue<int>(cups);

            var wastedWater = 0;

            while (stackBottles.Count != 0 && queCups.Count != 0)
            {
                var currentBottle = stackBottles.Peek();
                var currentCup = queCups.Peek();
                var currentDifferenceCup = 0;

                currentDifferenceCup += (currentCup - currentBottle);

                if (currentDifferenceCup <= 0)
                {
                    queCups.Dequeue();
                    stackBottles.Pop();
                    wastedWater += Math.Abs(currentDifferenceCup);
                }
                else if (currentDifferenceCup > 0)
                {
                    queCups.Dequeue();
                    var newList = queCups.ToList().Prepend(currentDifferenceCup);
                    queCups = new Queue<int>(newList);
                    stackBottles.Pop();
                }
            }

            if (queCups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", queCups)}");
            }

            if (stackBottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", stackBottles)}");
            }
            
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
