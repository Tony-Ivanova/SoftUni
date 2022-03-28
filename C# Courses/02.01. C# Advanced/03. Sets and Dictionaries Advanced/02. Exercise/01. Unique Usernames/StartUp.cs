namespace _01._Unique_Usernames
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            HashSet<string> list = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                list.Add(Console.ReadLine());
            }

            Console.WriteLine(string.Join(Environment.NewLine, list));
        }
    }
}
