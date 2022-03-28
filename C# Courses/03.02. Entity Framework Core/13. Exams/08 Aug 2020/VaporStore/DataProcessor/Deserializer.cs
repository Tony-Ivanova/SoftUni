namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {

        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedGames
            = "Added {0} ({1}) with {2} tags";

        private const string SuccessfullyImportedUsers
            = "Imported {0} with {1} cards";

        private const string SuccessfullyImportedPurchases
          = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesDto = JsonConvert.DeserializeObject<ImportGamesDevsGenreTagsDto[]>(jsonString);

            var sb = new StringBuilder();
            var games = new List<Game>();
            var developers = new List<Developer>();
            var genres = new List<Genre>();
            var tags = new List<Tag>();

            foreach (var gameDto in gamesDto)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime releaseDate;
                var isReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                if (!IsValid(isReleaseDateValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (gameDto.Tags.Length == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = releaseDate,
                };

                var developer = developers.FirstOrDefault(x => x.Name == gameDto.Developer);

                if (developer == null)
                {
                    developer = new Developer
                    {
                        Name = gameDto.Developer
                    };
                    developers.Add(developer);
                }

                game.Developer = developer;


                var genre = genres.FirstOrDefault(x => x.Name == gameDto.Genre);

                if (genre == null)
                {
                    genre = new Genre
                    {
                        Name = gameDto.Genre
                    };
                    genres.Add(genre);
                }

                game.Genre = genre;

                foreach (var tagName in gameDto.Tags)
                {
                    if (String.IsNullOrEmpty(tagName))
                    {
                        continue;
                    }

                    var tag = tags.FirstOrDefault(t => t.Name == tagName);
                    if (tag == null)
                    {
                        tag = new Tag
                        {
                            Name = tagName
                        };

                        tags.Add(tag);
                    }

                    game.GameTags.Add(new GameTag()
                    {
                        Game = game,
                        Tag = tag
                    });
                }

                games.Add(game);
                sb.AppendLine(string.Format(SuccessfullyImportedGames, game.Name, game.Genre.Name, game.GameTags.Select(x => x.TagId).Count()));
            }
            context.Games.AddRange(games);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var userCardsDto = JsonConvert.DeserializeObject<ImportUsersCardsDto[]>(jsonString);

            var validUsers = new List<User>();
            var sb = new StringBuilder();

            foreach (var userDto in userCardsDto)
            {
                if (!IsValid(userDto) || userDto.Cards.Length == 0 || !userDto.Cards.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age,
                };

                foreach (var card in userDto.Cards)
                {
                    user.Cards.Add(new Card
                    {
                        Number = card.Number,
                        Cvc = card.CVC,
                        Type = (CardType)Enum.Parse(typeof(CardType), card.Type)
                    });
                }

                validUsers.Add(user);
                sb.AppendLine(string.Format(SuccessfullyImportedUsers, user.Username, user.Cards.Count()));
            }
            context.Users.AddRange(validUsers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPurchasesDto[]), new XmlRootAttribute("Purchases"));
            var purchasesDto = (ImportPurchasesDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var validPurchases = new List<Purchase>();
            var sb = new StringBuilder();

            foreach (var purchaseDto in purchasesDto)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                PurchaseType purchaseType;
                var isPurchaseTypeValid = Enum.TryParse(purchaseDto.Type, out purchaseType);

                if (!isPurchaseTypeValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime purchaseDate;
                var isPurchaseDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out purchaseDate);

                if (!isPurchaseDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var purchase = new Purchase
                {
                    Game = context.Games.Single(x=>x.Name == purchaseDto.Title),
                    Type = purchaseType,
                    Card = context.Cards.Single(x=>x.Number == purchaseDto.Card),
                    ProductKey = purchaseDto.Key,
                    Date = purchaseDate,
                };

                validPurchases.Add(purchase);
                sb.AppendLine(string.Format(SuccessfullyImportedPurchases, purchaseDto.Title, purchase.Card.User.Username));
            }

            context.Purchases.AddRange(validPurchases);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}