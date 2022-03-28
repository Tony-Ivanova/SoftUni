namespace Einstein_s_Riddle
{
    using System;
    public class StartUp
    {
        static string[] houses = { "Red", "Green", "Yellow", "White", "Blue" };
        static string[] pets = { "Dog", "Cat", "Bird", "Horse", "Fish" };
        static string[] nationalities = { "Brit", "Swede", "Dane", "Norwegian", "German" };
        static string[] cigarettes = { "Blend", "Prince", "Dunhill", "BlueMaster", "PullMall" };
        static string[] drinks = { "Tea", "Coffee", "Milk", "Beer", "Water" };
        static string[] hints = new string[15];

        public static void Main()
        {
            Random random = new Random();
            Shuffle(random);
            GenerateHits();
            Console.WriteLine("Einstein`s riddle");
            Console.WriteLine("The situation:");
            Console.WriteLine("         1. There are 5 houses in 5 different colors.");
            Console.WriteLine("         2. In each house lives a person with a different nationality");
            Console.WriteLine("         3. These five owners drink a certain type of beverage, smoke a certain brand of cigar and keep a certain pet.");
            Console.WriteLine("         4. No owners have the same pet, smoke the same brand of cigar or drink the same beverage");

            Console.WriteLine($"The question is: Who owns the {pets[3]}?");
            Console.WriteLine("HINTS:");
            for (int i = 1; i <= hints.Length; i++)
            {
                Console.WriteLine($"{i}. {hints[i-1]}");
            }

            Console.WriteLine("Einstein wrote this riddle the previous century. He said that 98% of the world could not solve it");
            Console.WriteLine("To see the solution type solution");

            string solution = Console.ReadLine();

            while(solution.ToLower() != "solution")
            {
                Console.WriteLine("Wrong command! Try again!");
                solution = Console.ReadLine();
            }

            PrintSolution();
        }

        private static void PrintSolution()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"In the {houses[i]} lives the {nationalities[i]}. He drinks {drinks[i]}, smokes {cigarettes[i]} and has {pets[i]} as a pet.");
            }
        }

        private static void GenerateHits()
        {
            hints[0] = $"the {nationalities[2]} lives in the {houses[2]} house";
            hints[1] = $"the {nationalities[4]} keeps {pets[4]} as pet";
            hints[2] = $"the {nationalities[1]} drinks {drinks[1]}";
            hints[3] = $"the {houses[3]} house is on the left the {houses[4]} house";
            hints[4] = $"the {houses[3]} house's owner drinks {drinks[3]}";
            hints[5] = $"the person who smokes {cigarettes[0]} rears {pets[4]}";
            hints[6] = $"the owner of the {houses[4]} smokes {cigarettes[3]}";
            hints[7] = $"the man living in the last house drinks {drinks[2]}";
            hints[8] = $"the {nationalities[0]} lives in the first house";
            hints[9] = $"the man who smokes {cigarettes[2]} lives next to the one who keeps a {pets[1]}";
            hints[10] = $"the man who keeps a {pets[3]} lives next to the man who smokes {cigarettes[3]}";
            hints[11] = $"the owner who smokes {cigarettes[1]} drinks {drinks[4]}";
            hints[12] = $"the {nationalities[3]} smokes {cigarettes[4]}";
            hints[13] = $"the {nationalities[4]} lives next to the {houses[4]} house";
            hints[14] = $"the man who smokes {cigarettes[2]} has a neighbor who drinks {drinks[1]}";
        }

        private static void Shuffle(Random random)
        {
            for (int i = 0; i < 5; i++)
            {
                int randomHouse = i + random.Next(0, houses.Length - i);
                Swap(i, randomHouse, houses);

                int randomPet = i + random.Next(0, pets.Length - i);
                Swap(i, randomPet, pets);

                int randomNationality = i + random.Next(0, nationalities.Length - i);
                Swap(i, randomNationality, nationalities);

                int randomCigarettes = i + random.Next(0, cigarettes.Length - i);
                Swap(i, randomCigarettes, cigarettes);

                int randomDrinks = i + random.Next(0, drinks.Length - i);
                Swap(i, randomDrinks, drinks);
            }
        }

        private static void Swap(int i, int random, string[] array)
        {
            string temp = array[i];
            array[i] = array[random];
            array[random] = temp;
        }
    }
}