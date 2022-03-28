namespace _02._Randomize_Words
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var arrayOfWords = Console.ReadLine()
                .Split(new char[] { ' ' }, 
                StringSplitOptions.RemoveEmptyEntries);

            Random random = new Random();

            for (int i = 0; i < arrayOfWords.Length-1; i++)
            {
                int futureIndex = random.Next(0, arrayOfWords.Length);

                if(i != futureIndex)
                {
                    var old = arrayOfWords[i];
                    arrayOfWords[i] = arrayOfWords[futureIndex];
                    arrayOfWords[futureIndex] = old;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, arrayOfWords));
        }
    }
}
