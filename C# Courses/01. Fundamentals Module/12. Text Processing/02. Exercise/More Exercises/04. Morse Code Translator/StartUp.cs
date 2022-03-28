namespace _04._Morse_Code_Translator
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, char> morseCode = new Dictionary<string, char>();
            morseCode[".-"] = 'A';
            morseCode["-..."] = 'B';
            morseCode["-.-."] = 'C';
            morseCode["-.."] = 'D';
            morseCode["."] = 'E';
            morseCode["..-."] = 'F';
            morseCode["--."] = 'G';
            morseCode["...."] = 'H';
            morseCode[".."] = 'I';
            morseCode[".---"] = 'J';
            morseCode["-.-"] = 'K';
            morseCode[".-.."] = 'L';
            morseCode["--"] = 'M';
            morseCode["-."] = 'N';
            morseCode["---"] = 'O';
            morseCode[".--."] = 'P';
            morseCode["--.-"] = 'Q';
            morseCode[".-."] = 'R';
            morseCode["..."] = 'S';
            morseCode["-"] = 'T';
            morseCode["..-"] = 'U';
            morseCode["...-"] = 'V';
            morseCode[".--"] = 'W';
            morseCode["-..-"] = 'X';
            morseCode["-.--"] = 'Y';
            morseCode["--.."] = 'Z';
            morseCode["|"] = ' ';

            string message = Console.ReadLine();
            string[] letters = message.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
            string hiddenMessage = string.Empty;

            foreach (var letter in letters)
            {
                char latinLetter = morseCode[letter];
                hiddenMessage += latinLetter;
            }

            Console.WriteLine(hiddenMessage);
        }
    }
}
