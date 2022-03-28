namespace _11._Key_Revolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int pricePerBullet = int.Parse(Console.ReadLine());
            int barrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();
            var locks = Console.ReadLine()
                               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            int intelligence = int.Parse(Console.ReadLine());

            Queue<int> que = new Queue<int>(locks);
            Stack<int> stack = new Stack<int>(bullets);

            int count = 0;

            while (que.Any() && stack.Any())
            {
                int currentBullet = stack.Peek();
                int currentLock = que.Peek();

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

                count++;

                if (count == barrel && stack.Any())
                {
                    Console.WriteLine("Reloading!");
                    count = 0;
                }
            }

            if (que.Count == 0)
            {
                Console.WriteLine($"{stack.Count()} bullets left. Earned ${intelligence - ((bullets.Count() - stack.Count()) * pricePerBullet)}");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {que.Count()}");
            }
        }
    }
}
