namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context
                .Movies
                .Where(x => x.Rating >= rating && 
                            x.Projections
                            .Any(k => k.Tickets.Count >= 1))
                .OrderByDescending(x => x.Rating)
                .ThenByDescending(x => x.Projections
                                        .Sum(y => y.Tickets
                                        .Sum(p => p.Price)))
                .Take(10)
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("F2"),
                    TotalIncomes = x.Projections.Sum(y => y.Tickets
                                                           .Sum(p => p.Price))
                                                           .ToString("F2"),
                    Customers = x.Projections
                                 .SelectMany(t => t.Tickets)
                                 .Select(c => new
                    {
                        FirstName = c.Customer.FirstName,
                        LastName = c.Customer.LastName,
                        Balance = c.Customer.Balance.ToString("F2")
                    }).OrderByDescending(c => c.Balance)
                      .ThenBy(c => c.FirstName)
                      .ThenBy(c => c.LastName).ToArray()
                })
                .ToArray();

            var result = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);

            return result;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context
                .Customers
                .Where(x => x.Age >= age)
                .OrderByDescending(x => x.Tickets
                                         .Sum(p => p.Price))
                .Take(10)
                .Select(x => new CustomerDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets
                                  .Sum(y => y.Price)
                                  .ToString("F2"),
                    SpentTime = TimeSpan.FromSeconds(x.Tickets
                                                      .Sum(y => y.Projection.Movie.Duration.TotalSeconds))
                                                      .ToString(@"hh\:mm\:ss")
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CustomerDto[]), new XmlRootAttribute("Customers"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}