namespace Cinema
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class StartUp
    {
        public static void Main()
        {
            var myDict = new Dictionary<string, List<string>>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Done")
                {
                    break;
                }

                var tokens = input.Split(new string[] { " <=> ", " : " }, StringSplitOptions.RemoveEmptyEntries);
                var cinemaName = tokens[0];
                var movieName = tokens[1];
                var pricePerMovie = decimal.Parse(tokens[2]);

                if ((cinemaName.Contains('-') || cinemaName.Contains('>')) || cinemaName.Length >= 20)
                {
                    Console.WriteLine("Invalid cinema name");
                }
                else if ((movieName.Contains('-') || movieName.Contains('>')) || movieName.Length >= 20)
                {
                    Console.WriteLine("Invalid movie name");
                }
                else
                {
                    if (!myDict.ContainsKey(cinemaName))
                    {
                        myDict[cinemaName] = new List<string>();
                    }

                    string toBeAdded = $"{movieName} : {pricePerMovie}";

                    myDict[cinemaName].Add(toBeAdded);
                }
            }

            foreach (var item in myDict.OrderBy(x => x.Key))
            {
                Console.WriteLine("-" + " " + item.Key);

                foreach (string typeandNumber in item.Value.OrderByDescending(x => decimal.Parse(x.Split(new[] { " : " }, StringSplitOptions.None).Skip(1).First())))
                {
                    Console.WriteLine(typeandNumber);
                }
            }
        }
    }
}