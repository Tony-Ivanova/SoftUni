﻿namespace _04._Printing_Triangle
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine()); 
            PrintTriangle(n); 
        }

        private static void PrintLine(int start, int end)   
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " "); 
            }
            Console.WriteLine(); 
        }

        private static void PrintTriangle(int n)
        {
            for (int line = 1; line <= n; line++)   
                PrintLine(1, line);
            for (int line = n - 1; line >= 1; line--)   
                PrintLine(1, line);
        }
    }
}
