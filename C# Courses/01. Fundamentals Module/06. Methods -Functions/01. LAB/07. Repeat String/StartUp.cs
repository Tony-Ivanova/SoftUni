namespace _07._Repeat_String
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            string result = RepeatString(name, n);
            Console.WriteLine(result);
        }

        private static string RepeatString(string name, int n)
        {
            string result = string.Empty;
            for (int i = 0; i < n; i++)
            {
                result += name;
            }
            return result;
        }
    }
}
