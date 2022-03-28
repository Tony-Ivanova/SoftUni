namespace _08._Custom_Comparator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            Func<int, int, int> softFunc = (a, b) => a.CompareTo(b);
            Action<int[]> print = x => Console.Write(string.Join(" ", x));

            int[] evenNumbers = numbers.Where(x => x % 2 == 0).ToArray();
            int[] oddNumbers = numbers.Where(x => x % 2 != 0).ToArray();

            Array.Sort(evenNumbers, new Comparison<int>(softFunc));
            Array.Sort(oddNumbers, new Comparison<int>(softFunc));

            print(evenNumbers);
            Console.Write(" ");
            print(oddNumbers);
        }
    }
}

