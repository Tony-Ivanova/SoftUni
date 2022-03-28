using BattleCards.ViewModels.Card;
using System.Collections.Generic;


namespace BattleCards.Services
{
    public interface ICardsService
    {
        int Add(CardInputModel cardInput);

        bool CardAlreadyInCollection(string userId, int cardId);

        IEnumerable<CardsAllViewModel> GetAll();

        void AddCardToUserCollection(string userId, int cardId);

        void RemoveCardFromCollection(string userId, int cardId);

        IEnumerable<CardsAllViewModel> GetAllForThisUser(string userId);
    }
}
