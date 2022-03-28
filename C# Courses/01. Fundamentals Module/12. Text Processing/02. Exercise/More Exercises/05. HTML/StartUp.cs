namespace _05._HTML
{
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<h1>");
            sb.AppendLine(title);
            sb.AppendLine("</h1>");

            sb.AppendLine("<article>");
            sb.AppendLine(content);
            sb.AppendLine("</article>");

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of comments")
                {
                    break;
                }

                sb.AppendLine("<div>");
                sb.AppendLine(input);
                sb.AppendLine("</div>");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}