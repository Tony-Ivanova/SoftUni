namespace _05._Nether_Realms
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            string healtPattern = @"[^0-9+\-*\/.]";
            Regex healtRegex = new Regex(healtPattern);

            string digitsPattern = @"-?\d+\.?\d*";
            Regex digitRegex = new Regex(digitsPattern);

            string operatorPattern = @"[*\/]";
            Regex operatorRegex = new Regex(operatorPattern);

            string[] demonNames = Regex
                .Split(Console.ReadLine(), @"\s*,\s*")
                .OrderBy(x => x)
                .ToArray();

            for (int i = 0; i < demonNames.Length; i++)
            {
                string currentDemon = demonNames[i];

                int currentHealt = 0;

                MatchCollection healtSymbols = healtRegex.Matches(currentDemon);

                foreach (Match symbol in healtSymbols)
                {
                    currentHealt += char.Parse(symbol.Value);
                }

                MatchCollection digitMatch = digitRegex.Matches(currentDemon);

                double baseDamage = 0;

                foreach (Match number in digitMatch)
                {
                    baseDamage += double.Parse(number.Value);
                }

                MatchCollection operatorMatch = operatorRegex.Matches(currentDemon);

                foreach (Match oper in operatorMatch)
                {
                    string @operator = oper.Value;

                    if (@operator == "*")
                    {
                        baseDamage *= 2;
                    }
                    else
                    {
                        baseDamage /= 2;
                    }
                }

                Console.WriteLine($"{currentDemon} - {currentHealt} health, {baseDamage:f2} damage");
            }
        }
    }
}
