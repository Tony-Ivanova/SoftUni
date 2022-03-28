namespace _10._Rage_Expenses
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int lostGameCount = int.Parse(Console.ReadLine());

            decimal headsetPrice = decimal.Parse(Console.ReadLine());
            int headsetByeBye = 0;

            decimal mousePrice = decimal.Parse(Console.ReadLine());
            int mouseByeBye = 0;

            decimal keyboardPrice = decimal.Parse(Console.ReadLine());
            int keyboardByeBye = 0;

            decimal displayPrice = decimal.Parse(Console.ReadLine());
            int displayByeBye = 0;

            for (int i = 1; i <= lostGameCount; i++)
            {
                if (i % 2 == 0)
                {
                    headsetByeBye++;
                }
                if (i % 3 == 0)
                {
                    mouseByeBye++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    keyboardByeBye++;
                    if (keyboardByeBye % 2 == 0)
                    {
                        displayByeBye++;
                    }
                }
            }

            decimal moneyOutOfTheWindow = (headsetByeBye * headsetPrice) + (mouseByeBye * mousePrice) + (displayByeBye * displayPrice) + (keyboardByeBye * keyboardPrice);

            Console.WriteLine($"Rage expenses: {moneyOutOfTheWindow:f2} lv.");
        }
    }
}
