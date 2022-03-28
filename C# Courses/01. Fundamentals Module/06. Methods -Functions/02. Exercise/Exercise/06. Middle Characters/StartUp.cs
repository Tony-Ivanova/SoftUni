namespace _06._Middle_Characters
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            string middle = Mid(name);
            Console.WriteLine(middle);
        }

        private static string Mid(string name)
        {
            string middle = string.Empty;

            if (name.Length % 2 == 0)
            {
                middle = name.Substring(name.Length / 2 - 1, 2);
            }
            else if (name.Length % 2 != 0)
            {
                middle = name.Substring(name.Length / 2, 1);
            }

            return middle;
        }
    }
}
