namespace _03._Treasure_Finder
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] key = Console.ReadLine()
                               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "find")
                {
                    break;
                }

                int keyLength = key.Length;
                int inputLengh = input.Length;
                int counter = 0;
                string hiddenMessage = string.Empty;

                for (int i = 0; i < input.Length; i++)
                {
                    if(counter == keyLength)
                    {
                        counter = 0;
                    }

                    int currentLetterASCII = input[i];
                    int currentKey = key[counter];

                    hiddenMessage += (char)(currentLetterASCII - currentKey);
                    counter++;
                }

                int beginningOfType = hiddenMessage.IndexOf('&') + 1;
                int endOfType = hiddenMessage.LastIndexOf('&');

                int beginningOfCoordinates = hiddenMessage.IndexOf('<') + 1;
                int endOfCoordinates = hiddenMessage.IndexOf('>');

                string type = hiddenMessage.Substring(beginningOfType, endOfType - beginningOfType);
                string coordinates = hiddenMessage.Substring(beginningOfCoordinates, endOfCoordinates - beginningOfCoordinates);

                Console.WriteLine($"Found {type} at {coordinates}");
            }
        }
    }
}
