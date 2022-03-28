namespace BorderControl
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {           
            var robotsAndCitizens = new List<IIdentification>();

            while(true)
            {
                string input = Console.ReadLine();

                if(input == "End")
                {
                    break;
                }

                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if(tokens.Length == 3)
                {
                    var name = tokens[0];
                    var age = int.Parse(tokens[1]);
                    var id = tokens[2];

                    var citizen = new Citizen(name, age, id);

                    robotsAndCitizens.Add(citizen);
                }
                else if(tokens.Length == 2)
                {
                    var model = tokens[0];                    
                    var id = tokens[1];
                    var robot = new Robot(model, id);
                    robotsAndCitizens.Add(robot);
                }
            }

            var lastDigitsOfFakeIds = Console.ReadLine();

            foreach (var currentCitizen in robotsAndCitizens)
            {
                var currentId = currentCitizen.Id;

                if (currentId.EndsWith(lastDigitsOfFakeIds))
                {
                    Console.WriteLine(currentId);
                }
            }
        }
    }
}
