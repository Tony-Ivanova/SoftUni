namespace _02._Articles
{
    using System;

    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    public class StartUp
    {
        public static void Main()
        {
            string[] articleProps = Console.ReadLine()
                .Split(", ");

            string title = articleProps[0];
            string content = articleProps[1];
            string author = articleProps[2];

            Article article = new Article(title, content, author);

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] splittedInput = Console.ReadLine()
                    .Split(": ");

                string command = splittedInput[0];

                if (command == "Edit")
                {
                    string newContent = splittedInput[1];

                    article.Edit(newContent);
                }
                else if (command == "ChangeAuthor")
                {
                    string newAuthor = splittedInput[1];

                    article.ChangeAuthor(newAuthor);
                }
                else if (command == "Rename")
                {
                    string newTitle = splittedInput[1];

                    article.Rename(newTitle);
                }
            }
            Console.WriteLine(article);
        }
    }
}