using BattleCards.Data;
using BattleCards.Models;
using BattleCards.ViewModels.Card;
using System.Collections.Generic;
using System.Linq;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;

        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int Add(CardInputModel cardInput)
        {
            var card = new Card
            {
                Name = cardInput.Name,
                ImageUrl = cardInput.Image,
                Keyword = cardInput.Keyword,
                Attack = cardInput.Attack,
                Health = cardInput.Health,
                Description = cardInput.Description
            };

            this.db.Cards.Add(card);
            this.db.SaveChanges();

            return card.Id;
        }

        public void AddCardToUserCollection(string userId, int cardId)
        {
            var card = this.db.Cards.FirstOrDefault(x => x.Id == cardId);

            var cardToUser = new UserCard
            {
                UserId = userId,
                CardId = cardId
            };

            this.db.UserCards.Add(cardToUser);
            this.db.SaveChanges();
        }

        public bool CardAlreadyInCollection(string userId, int cardId)
        {
            return this.db.UserCards.Any(x => x.UserId == userId && x.CardId == cardId);
        }

        public IEnumerable<CardsAllViewModel> GetAll()
        {
            var cards = this.db.Cards.Select(x=>new CardsAllViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Keyword = x.Keyword,
                Attack = x.Attack,
                Health = x.Health,
                Description = x.Description
            }).ToArray();
            
            return cards;
        }

        public IEnumerable<CardsAllViewModel> GetAllForThisUser(string userId)
        {
            var cards = this.db.UserCards.Where(x=>x.UserId == userId)
            .Select(x => new CardsAllViewModel
            {
                Id = x.Card.Id,
                Name = x.Card.Name,
                ImageUrl = x.Card.ImageUrl,
                Keyword = x.Card.Keyword,
                Attack = x.Card.Attack,
                Health = x.Card.Health,
                Description = x.Card.Description
            }).ToArray();

            return cards;
        }

        public void RemoveCardFromCollection(string userId, int cardId)
        {
            var card = this.db.Cards.FirstOrDefault(x => x.Id == cardId);

            var cardToUser = new UserCard
            {
                UserId = userId,
                CardId = cardId
            };

            this.db.UserCards.Remove(cardToUser);
            this.db.SaveChanges();
        }
    }
}
