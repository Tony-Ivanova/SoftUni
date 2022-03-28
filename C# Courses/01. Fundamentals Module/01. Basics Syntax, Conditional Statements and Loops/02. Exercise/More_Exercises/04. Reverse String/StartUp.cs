namespace _04._Reverse_String
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var wordToBeReversed = Console.ReadLine().ToCharArray();
            Array.Reverse(wordToBeReversed);
            var reversedWord = new string(wordToBeReversed);

            Console.WriteLine(reversedWord);
        }
    }
}
