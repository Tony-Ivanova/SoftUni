namespace BookShop
{

    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                // DbInitializer.ResetDatabase(db);

                //string input = Console.ReadLine();
                //int lengthCheck = int.Parse(Console.ReadLine());

                string result = GetGoldenBooks(db);

                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();


            var books = context
                .Books
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .OrderBy(b => b.Title)
                .Select(b => b.Title);

            foreach (var b in books)
            {
                sb.AppendLine(b);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var goldBooks = context.Books
            .Where(b => b.EditionType == (EditionType)2)
            .Where(b => b.Copies < 5000)
            .OrderBy(b => b.BookId)
            .Select(b => b.Title);


            foreach (var b in goldBooks)
            {
                sb.AppendLine(b);
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksWithPriceAbove40 = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(e => new
                {
                    e.Title,
                    e.Price
                });


            foreach (var b in booksWithPriceAbove40)
            {
                sb.AppendLine($"{b.Title} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var booksNotReleasedThisYear = context.Books
                .Where(b => DateTime.Parse(b.ReleaseDate.ToString()).Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title);

            foreach (var v in booksNotReleasedThisYear)
            {
                sb.AppendLine(v);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var listOfCategories = input
                .ToLower()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var booksFromCategories = context
                .Books
                .Where(b => b.BookCategories
                            .Any(bc => listOfCategories
                                .Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title);


            foreach (var b in booksFromCategories)
            {
                sb.AppendLine(b);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new StringBuilder();


            var books = context.Books
                .Where(b => b.ReleaseDate < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .OrderByDescending(b => b.ReleaseDate)
                .Select(e => new
                {
                    e.Title,
                    e.EditionType,
                    e.Price
                });


            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var booksWithAuthors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName
                });

            foreach (var b in booksWithAuthors)
            {
                sb.AppendLine($"{b.FirstName} {b.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var titlesContaining = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title);

            foreach (var b in titlesContaining)
            {
                sb.AppendLine(b);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var titlesAndAuthors = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(e => new
                {
                    e.Title,
                    Author = $"{e.Author.FirstName} {e.Author.LastName}"
                })
                .ToList();


            foreach (var b in titlesAndAuthors)
            {
                sb.AppendLine($"{b.Title} ({b.Author})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var numberOfBooks = context.Books
                .Where(b => b.Title.Length > lengthCheck);

            return numberOfBooks.Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var bookCount = context.Authors
                .Select(e => new
                {
                    Name = $"{e.FirstName} {e.LastName}",
                    Copies = e.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(e => e.Copies)
                .ToList();

            foreach (var b in bookCount)
            {
                sb.AppendLine($"{b.Name} - {b.Copies}");
            }

            return sb.ToString().TrimEnd();
        }


        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var profitByCategory = context.Categories
                .Select(e => new
                {
                    e.Name,
                    Profit = e.CategoryBooks
                                .Select(cb => cb.Book.Price * cb.Book.Copies).Sum()
                })
                .OrderByDescending(e => e.Profit);


            foreach (var b in profitByCategory)
            {
                sb.AppendLine($"{b.Name} ${b.Profit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var mostRecentBooksByCategory = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    CategoryRecentBooks = c.CategoryBooks
                                                .OrderByDescending(cb => cb.Book.ReleaseDate)
                                                .Take(3)
                                                .Select(cb => new
                                                {
                                                    BookTitle = cb.Book.Title,
                                                    BookRelease = cb.Book.ReleaseDate.Value.Year
                                                })
                                                .ToList()
                });




            foreach (var b in mostRecentBooksByCategory)
            {
                sb.AppendLine($"--{b.Name}");

                foreach (var c in b.CategoryRecentBooks)
                {
                    sb.AppendLine($"{c.BookTitle} ({c.BookRelease})");
                }
            }

            return sb.ToString().TrimEnd();

        }


        public static void IncreasePrices(BookShopContext context)
        {
            var bookPriceIncrease = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var b in bookPriceIncrease)
            {
                b.Price += 5;
            }

            context.SaveChanges();
        }


        public static int RemoveBooks(BookShopContext context)
        {
            var booksToBeRemoved = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(booksToBeRemoved);
            context.SaveChanges();

            return booksToBeRemoved.Count();
        }

    }
}
