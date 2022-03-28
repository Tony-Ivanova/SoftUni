using SharedTrip.Services;
using SharedTrip.ViewModels.TripViews;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trips = this.tripsService.GetAll();

            return this.View(trips);
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
        public HttpResponse Add(TripInputModel tripInputModel)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("Users/Login");
            }

            if (tripInputModel.Seats < 2 || tripInputModel.Seats > 6)
            {
                return this.View();
            }

            if (tripInputModel.Description.Length > 80)
            {
                return this.View();
            }

            var tripId = this.tripsService.Add(tripInputModel);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trip = this.tripsService.GetById(tripId);

            return this.View(trip);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            var userId = this.User;

            var isUserAlreadyInCurrentTrip = this.tripsService.IsUserAlreadyInCurrentTrip(userId, tripId);

            if (isUserAlreadyInCurrentTrip)
            {
                return this.Redirect($"/Trips/Details?tripId={tripId}");
            }

            this.tripsService.AddUserToTrip(userId, tripId);

            return this.Redirect("/Trips/All");
        }
    }
}
