namespace _05._Login
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            string userName = Console.ReadLine();
            string reverseUserName = string.Empty;
            int count = 0;

            for (int i = userName.Length - 1; i >= 0; i--)
            {
                reverseUserName += userName[i];
            }


            string newPass = userName;
            for (int i = 1; i < 5; i++)
            {
                newPass = Console.ReadLine();
                if (reverseUserName == newPass)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }
                else if (reverseUserName != newPass)
                {
                    count++;
                    if (count == 4)
                    {
                        Console.WriteLine($"User {userName} blocked!");
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
        }
    }
}
