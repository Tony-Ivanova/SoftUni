namespace _06._Triples_of_Latin_Letters
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            for (int first = 0; first < number; first++)
            {

                for (int second = 0; second < number; second++)
                {

                    for (int third = 0; third < number; third++)
                    {

                        Console.WriteLine($"{(char)(first+97)}{(char)(second+97)}{(char)(third+97)}");
                    }
                }
            }
        }
    }
}