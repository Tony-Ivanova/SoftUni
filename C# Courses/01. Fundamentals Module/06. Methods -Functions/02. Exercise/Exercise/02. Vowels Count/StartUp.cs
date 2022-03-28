namespace _02._Vowels_Count
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            int result = VowelsCount(name);
            Console.WriteLine(result);
        }
        private static int VowelsCount(string name)
        {
            int result = 0;
            string vowels = "aeiou";

            for (int i = 0; i < name.Length; i++)
            {
                if (vowels.Contains(name[i]))
                {
                    result++;
                }
            }
            return result;
        }
    }
}