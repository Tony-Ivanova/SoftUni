namespace _12._TriFunction
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Func<string, char[]> funcToChar = x => x.ToCharArray();
            Func<char, int> castFunc = y => (int)y;
            Func<string, bool> finalFunc = x => funcToChar(x).Select(castFunc).Sum() >= number;

            Console.WriteLine(Console.ReadLine()
                                     .Split()
                                     .FirstOrDefault(finalFunc));
        }
    }
}