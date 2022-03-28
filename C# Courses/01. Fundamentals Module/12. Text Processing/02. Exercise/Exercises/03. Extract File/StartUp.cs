namespace _03._Extract_File
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string path = Console.ReadLine();

            int startIndexOfFile = path.LastIndexOf('\\') + 1;
            string file = path.Substring(startIndexOfFile);
            int startIndexOfExtention = file.LastIndexOf('.') + 1;
            string name = file.Substring(0, startIndexOfExtention - 1);
            string extention = file.Substring(startIndexOfExtention);

            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extention}");
        }
    }
}
