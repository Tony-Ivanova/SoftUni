namespace _05._Record_Unique_Names
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < number; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }

            Console.WriteLine(string.Join(Environment.NewLine, names));            
        }
    }
}
