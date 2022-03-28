namespace _04._The_Kitchen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var knives = Console.ReadLine()
                                .Split(new char[] { ' ' }, StringSplitOptions
                                .RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToList();

            var forks = Console.ReadLine()
                               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            var stack = new Stack<int>(knives);
            var que = new Queue<int>(forks);

            var sets = new List<int>();

            while (stack.Count != 0 && que.Count != 0)
            {
                var currentSet = 0;
                var currentKnife = stack.Peek();
                var currentFork = que.Peek();

                if (currentKnife > currentFork)
                {
                    currentSet += currentKnife + currentFork;
                    sets.Add(currentSet);
                    stack.Pop();
                    que.Dequeue();
                }
                else if (currentKnife < currentFork)
                {
                    stack.Pop();
                }
                else if (currentKnife == currentFork)
                {
                    que.Dequeue();
                    int newKnife = currentKnife + 1;
                    stack.Pop();
                    stack.Push(newKnife);
                }
            }

            var biggestSet = sets.Max();
            Console.WriteLine($"The biggest set is: {biggestSet}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
