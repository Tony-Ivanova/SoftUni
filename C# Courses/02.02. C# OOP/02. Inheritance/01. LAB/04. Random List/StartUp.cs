﻿namespace CustomRandomList
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var list = new RandomList();
            list.Add("cat");
            list.Add("dog");
            list.Add("puppy");

            Console.WriteLine(list.RandomString());
        }
    }
}
