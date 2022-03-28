namespace _04._Fast_Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                                  .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToArray();
            Queue<int> que = new Queue<int>(orders);
            Console.WriteLine(que.Max());
            bool notEnough = false;

            while (quantityOfFood >= 0)
            {
                if (que.Count == 0)
                {
                    break;
                }
                else
                {
                    int currentOrder = que.Peek();
                    if (currentOrder > quantityOfFood)
                    {
                        notEnough = true;
                        break;
                    }
                    else
                    {
                        quantityOfFood -= currentOrder;
                        que.Dequeue();
                    }
                }
            }

            if (quantityOfFood >= 0 && notEnough == false)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", que)}");
            }
        }
    }
}
