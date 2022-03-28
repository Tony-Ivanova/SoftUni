namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;   

    public class StartUp
    {
        public static void Main()
        {
           
            var citizensAndPets = new List<IBirthday>();

            while(true)
            {
                string input = Console.ReadLine();

                if(input == "End")
                {
                    break;
                }

                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var typeOfCitizen = tokens[0];

                if(typeOfCitizen == "Citizen")
                {
                    var name = tokens[1];
                    var age = int.Parse(tokens[2]);
                    var id = tokens[3];
                    var birthday = tokens[4];

                    var citizen = new Citizen(name, age, id, birthday);

                    citizensAndPets.Add(citizen);
                }
                else if(typeOfCitizen == "Robot")
                {
                    var model = tokens[1];                    
                    var id = tokens[2];

                    var robot = new Robot(model, id);
                    //robotsAndCitizens.Add(robot);
                }
                else if(typeOfCitizen == "Pet")
                {
                    var name = tokens[1];
                    var birthday = tokens[2];

                    var pet = new Pet(name, birthday);

                    citizensAndPets.Add(pet);
                }
            }

            var birthdayYear = Console.ReadLine();

            foreach (var currentCitizenOrPet in citizensAndPets)
            {
                var currentBirthday = currentCitizenOrPet.Birthday;
                if (currentBirthday.EndsWith(birthdayYear))
                {
                    Console.WriteLine(currentBirthday);
                }
            }
        }
    }
}
