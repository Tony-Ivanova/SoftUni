namespace _04._Text_Filter
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] wordsToBann = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            foreach (var bannedWord in wordsToBann)
            {
                if(text.Contains(bannedWord))
                { 
                   string newWord = new string('*', bannedWord.Length);
                   text = text.Replace(bannedWord, newWord);
                    
                }
            }

            Console.WriteLine(string.Join(" ", text));
        }
    }
}
