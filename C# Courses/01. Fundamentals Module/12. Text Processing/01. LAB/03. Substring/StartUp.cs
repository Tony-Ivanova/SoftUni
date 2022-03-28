namespace _03._Substring
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string firstWord = Console.ReadLine().ToLower();
            string secondWord = Console.ReadLine().ToLower();

            int index = -1;

            while (true)
            {
                index = secondWord.IndexOf(firstWord);

                if(index < 0)
                {
                    break;
                }

                secondWord = secondWord.Remove(index, firstWord.Length);
            }

            Console.WriteLine(secondWord);
        }
    }
}
