namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authorsWithBooks = context
                .Authors
                .Select(a => new
                {
                    AuthorName = a.FirstName + ' ' + a.LastName,
                    Books = a.AuthorsBooks
                             .OrderByDescending(x => x.Book.Price)
                    .Select(b => new
                    {
                        BookName = b.Book.Name,
                        BookPrice = b.Book.Price.ToString("f2")
                    })
                    .ToArray()
                })
                .ToArray()
                .OrderByDescending(a => a.Books.Length)
                .ThenBy(a => a.AuthorName)
                .ToArray();

            var result = JsonConvert.SerializeObject(authorsWithBooks, Formatting.Indented);

            return result;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var oldestBooks = context
                .Books
                .Where(b => b.PublishedOn < date && b.Genre == Genre.Science)
                .ToArray()
                .OrderByDescending(b => b.Pages)
                .ThenByDescending(b => b.PublishedOn)
                .Take(10)
                .Select(b => new BookDto
                {
                    Name = b.Name,
                    Date = b.PublishedOn.ToString("d", CultureInfo.InvariantCulture),
                    Pages = b.Pages,
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(BookDto[]), new XmlRootAttribute("Books"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                XmlQualifiedName.Empty
            });

            xmlSerializer.Serialize(new StringWriter(sb), oldestBooks, namespaces);

            return sb.ToString().TrimEnd();

        }
    }
}