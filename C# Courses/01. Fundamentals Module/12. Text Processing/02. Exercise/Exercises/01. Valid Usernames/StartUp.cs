namespace _01._Valid_Usernames
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string[] usernames = Console.ReadLine().Split(", ");

            List<string> validUsernames = new List<string>();

            for (int i = 0; i < usernames.Length; i++)
            {
                string username = usernames[i];

                if (username.Length >= 3 && username.Length <= 16)
                {
                    bool validateCandidate = ValidateUsernameContent(username);

                    if (validateCandidate == true)
                    {
                        validUsernames.Add(username);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, validUsernames));
        }

        private static bool ValidateUsernameContent(string username)
        {
            foreach (var symbol in username)
            {
                if (char.IsLetterOrDigit(symbol) || symbol == '_' || symbol == '-')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}