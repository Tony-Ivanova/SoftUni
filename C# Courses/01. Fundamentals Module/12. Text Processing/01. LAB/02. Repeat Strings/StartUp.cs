namespace _02._Repeat_Strings
{
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split();
            StringBuilder result = new StringBuilder();

            foreach (var word in words)
            {
                int timesToBeRepeated = word.Length;

                for (int i = 0; i < timesToBeRepeated; i++)
                {
                    result.Append(word);
                }
            }

            Console.WriteLine(result);
        }
    }
}
