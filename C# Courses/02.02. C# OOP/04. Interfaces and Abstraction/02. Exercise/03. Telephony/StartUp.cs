namespace Telephony
{
    using System;
    public class StartUp
    {
        public static void Main()
        {

            var seriesOfNumbers = Console.ReadLine()
                                         .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var seriesOfURLS = Console.ReadLine()
                                      .Split();

            var currenTelephone = new Smartphone();

            foreach (var currentNumber in seriesOfNumbers)
            {
                Console.WriteLine(currenTelephone.Calling(currentNumber));
            }

            foreach (var currentUrl in seriesOfURLS)
            {
                Console.WriteLine(currenTelephone.Browsing(currentUrl));
            }
        }
    }
}
