namespace _05._Applied_Arithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Func<List<int>, List<int>> addFunc = x => x.Select(a => a += 1).ToList();
            Func<List<int>, List<int>> substractFunc = x => x.Select(a => a -= 1).ToList();
            Func<List<int>, List<int>> multiplyFunc = x => x.Select(a => a *= 2).ToList();

            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));


            var numbers = Console.ReadLine()
                                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToList();

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "end")
                {
                    break;
                }
                else if (commands == "add")
                {
                    numbers = addFunc(numbers);
                }
                else if (commands == "subtract")
                {
                    numbers = substractFunc(numbers);
                }
                else if (commands == "multiply")
                {
                    numbers = multiplyFunc(numbers);
                }
                else if (commands == "print")
                {
                    print(numbers);
                }
            }
        }
    }
}