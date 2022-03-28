namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDto = JsonConvert.DeserializeObject<ImportMoviesDto[]>(jsonString);

            var validMovies = new List<Movie>();
            var sb = new StringBuilder();


            foreach (var movieDto in moviesDto)
            {
                if (!IsValid(movieDto)
                    || validMovies.Any(x => x.Title == movieDto.Title)
                    || !Enum.TryParse(typeof(Genre), movieDto.Genre, out object genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = (Genre)Enum.Parse(typeof(Genre), movieDto.Genre),
                    Duration = movieDto.Duration,
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                };

                validMovies.Add(movie);
                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("F2")));
            }

            context.Movies.AddRange(validMovies);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }


        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDto = JsonConvert.DeserializeObject<ImportHallsDto[]>(jsonString);

            var validHallSeats = new List<Hall>();

            var sb = new StringBuilder();

            foreach (var hallDto in hallsDto)
            {
                if (!IsValid(hallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is4Dx = hallDto.Is4Dx,
                    Is3D = hallDto.Is3D
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                validHallSeats.Add(hall);

                string status = string.Empty;

                if (hall.Is4Dx)
                {
                    status = hall.Is3D ? "4Dx/3D" : "4Dx";
                }
                else if (hall.Is3D)
                {
                    status = "3D";
                }
                else
                {
                    status = "Normal";
                }

                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, status, hall.Seats.Count));
            }

            context.Halls.AddRange(validHallSeats);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));
            var projectionsDto = (ImportProjectionDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var validProjections = new List<Projection>();
            var sb = new StringBuilder();

            foreach (var projectionDto in projectionsDto)
            {
                if (!IsValid(projectionDto) 
                    || !context.Movies.Any(x => x.Id == projectionDto.MovieId) 
                    || !context.Halls.Any(y => y.Id == projectionDto.HallId))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = projectionDto.MovieId,
                    HallId = projectionDto.HallId,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, @"yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                validProjections.Add(projection);
                sb.AppendLine(string.Format(SuccessfulImportProjection, context.Movies.FirstOrDefault(x => x.Id == projectionDto.MovieId).Title, projection.DateTime.ToString(@"MM/dd/yyyy")));
            }

            context.Projections.AddRange(validProjections);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));
            var customersDto = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var validCustomers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                if (!IsValid(customerDto)
                    || !customerDto.Tickets.All(IsValid)
                    || !context.Projections.Select(x => x.Id)
                                           .ToArray()
                                           .Any(x => customerDto.Tickets.Any(y => y.ProjectionId == x)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance
                };

                foreach (var ticket in customerDto.Tickets)
                {
                    customer.Tickets.Add(new Ticket
                    {
                        ProjectionId = ticket.ProjectionId,
                        Price = ticket.Price
                    });
                }

                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count));
                validCustomers.Add(customer);
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            var result = Validator.TryValidateObject(dto, validationContext, validationResult, true);

            return result;
        }
    }
}