namespace CustomStack
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var stack = new StackOfStrings();

            var list = new List<string>
            {
                "1", "2", "3"
            };

            stack.AddRange(list.ToArray());
        }
    }
}
