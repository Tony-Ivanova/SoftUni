namespace Telephony
{
    using System.Linq;
    public class Smartphone : IBrowser, ICaller
    {
        public string Model => "Smartphone";

        public string Browsing(string url)
        {
            if (url.Any(char.IsDigit))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {url}!";
        }

        public string Calling(string phone)
        {

            if (!phone.Any(char.IsDigit))
            {
                return "Invalid number!";
            }

            return $"Calling... {phone}";
        }
    }
}
