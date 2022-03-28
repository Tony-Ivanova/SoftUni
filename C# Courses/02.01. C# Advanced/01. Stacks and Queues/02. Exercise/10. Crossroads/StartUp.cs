namespace _10._Crossroads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            int passed = 0;
            bool isCrashed = false;

            Queue<string> que = new Queue<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }
                else if (input == "green")
                {
                    int timeLeft = greenLight;
                    string currentCar = "";

                    while (0 < timeLeft && que.Any())
                    {
                        currentCar = que.Dequeue();
                        passed++;
                        timeLeft -= currentCar.Count();
                    }

                    int timeWindow = timeLeft + freeWindow;

                    if (timeWindow < 0)
                    {
                        int howMany = Math.Abs(timeWindow);
                        int where = currentCar.Length - howMany;
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {currentCar[where]}.");
                        isCrashed = true;
                        break;
                    }
                }
                else
                {
                    que.Enqueue(input);
                }
            }

            if (isCrashed == false)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passed} total cars passed the crossroads.");
            }
        }
    }
}
