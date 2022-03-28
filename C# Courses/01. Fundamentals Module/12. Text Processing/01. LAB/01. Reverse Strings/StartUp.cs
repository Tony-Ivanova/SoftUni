namespace _01._Reverse_Strings
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();

                if(input == "end")
                {
                    break;
                }

                char[] wordToCharArray = input.ToCharArray();
                Array.Reverse(wordToCharArray);
                string reversedWord = new string(wordToCharArray);


                Console.WriteLine($"{input} = {reversedWord}");
            }
        }
    }
}
