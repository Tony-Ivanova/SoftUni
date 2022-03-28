namespace _01._Extract_Person_Information
{
    using System;
    
    public class StartUp
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string input = Console.ReadLine();

                int beginningOfName = input.IndexOf('@') + 1;
                int endOfName = input.IndexOf('|');

                int beginningOfAge = input.IndexOf('#') + 1;
                int endOfAge = input.IndexOf('*');

                string name = input.Substring(beginningOfName, endOfName- beginningOfName);
                string age = input.Substring(beginningOfAge, endOfAge - beginningOfAge);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
