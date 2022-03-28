namespace _09._Palindrome_Integers
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    break;
                }
                bool result = isPalindrome(command);
                Console.WriteLine(result.ToString().ToLower());
            }
        }

        public static bool isPalindrome(string command)
        {
            bool isPal = true;
            for (int i = 0; i < command.Length / 2; i++)
            {
                if (command[i] != command[command.Length - 1 - i])
                {
                    return isPal = false;
                }
            }
            return isPal;

        }
    }
}