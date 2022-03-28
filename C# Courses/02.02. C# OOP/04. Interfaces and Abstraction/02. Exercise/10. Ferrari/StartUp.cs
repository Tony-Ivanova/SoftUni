namespace Ferrari
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            var ferrari = new Ferrari(name);

            Console.WriteLine(ferrari);
        }
    }
}
