namespace _05._Multiply_Big_Number
{
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            string numAsString = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());
            int reminder = 0;
            StringBuilder result = new StringBuilder();

            if (multiplier == 0)
            {
                Console.WriteLine(0);
            }

            for (int i = numAsString.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(numAsString[i].ToString());
                int currentSum = digit * multiplier + reminder;
                reminder = currentSum / 10;
                result.Append(currentSum % 10);
            }

            result.Append(reminder);

            string output = result.ToString().TrimEnd('0');

            for (int i = output.Length - 1; i >= 0; i--)
            {
                Console.Write(output[i]);
            }
        }
    }
}
