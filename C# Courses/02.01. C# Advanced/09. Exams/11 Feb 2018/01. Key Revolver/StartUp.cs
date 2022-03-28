namespace Key_revolver
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var pricePerBullet = int.Parse(Console.ReadLine());
            var sizeBarrel = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine()
                                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToList();

            var locks = Console.ReadLine()
                               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToList();

            var value = int.Parse(Console.ReadLine());

            var que = new Queue<int>(locks);
            var stack = new Stack<int>(bullets);

            var counter = 0;

            while (que.Any() && stack.Any())
            {
                var currentBullet = stack.Peek();
                var currentLock = que.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    que.Dequeue();
                    stack.Pop();
                }
                else
                {
                    Console.WriteLine("Ping!");
                    stack.Pop();
                }

                counter++;

                if (counter == sizeBarrel && stack.Any())
                {
                    Console.WriteLine("Reloading!");
                    counter = 0;
                }
            }
            if (que.Count == 0)
            {
                Console.WriteLine($"{stack.Count()} bullets left. Earned ${value - ((bullets.Count() - stack.Count()) * pricePerBullet)}");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {que.Count()}");
            }
        }
    }
}