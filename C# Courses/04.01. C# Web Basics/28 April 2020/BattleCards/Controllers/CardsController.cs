using BattleCards.Services;
using BattleCards.ViewModels.Card;
using SIS.HTTP;
using SIS.MvcFramework;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(CardInputModel cardInput)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if(string.IsNullOrEmpty(cardInput.Name) || string.IsNullOrWhiteSpace(cardInput.Name))
            {
                return this.Error("Please enter a valid name for the card");
            }

            if(cardInput.Name?.Length < 5 || cardInput.Name?.Length > 15)
            {
                return this.Error("The name of the card must be between 5 and 15 characters");
            }

            if(cardInput.Attack < 0)
            {
                return this.Error("The attack can't be below 0");
            }

            if(cardInput.Health < 0)
            {
                return this.Error("The health can't be below 0");
            }

            if(cardInput.Description.Length < 1 || cardInput.Description.Length > 200)
            {
                return this.Error("The length of the description has to be between 1 and 200 characters");
            }

            var cardId = this.cardsService.Add(cardInput);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var cards = this.cardsService.GetAll();

            return this.View(cards);
        }
    
        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.User;

            if(cardsService.CardAlreadyInCollection(userId, cardId))
            {
                return this.Redirect("/Cards/All");
            }

            this.cardsService.AddCardToUserCollection(userId, cardId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.User;

            if (!cardsService.CardAlreadyInCollection(userId, cardId))
            {
                return this.Error("Card is not part of the collection");
            }

            this.cardsService.RemoveCardFromCollection(userId, cardId);

            return this.Redirect("/Cards/Collection");
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.User;

            var cardsInCollection = this.cardsService.GetAllForThisUser(userId);

            return this.View(cardsInCollection);
        }
    }
}
