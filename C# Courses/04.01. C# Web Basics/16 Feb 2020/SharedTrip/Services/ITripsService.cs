using SharedTrip.Models;
using SharedTrip.ViewModels.TripViews;
using System.Collections.Generic;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        IEnumerable<Trip> GetAll();

        string Add(TripInputModel tripInputModel);

        Trip GetById(string tripId);

        bool IsUserAlreadyInCurrentTrip(string userId, string tripId);

        void AddUserToTrip(string userId, string tripId);
    }
}
